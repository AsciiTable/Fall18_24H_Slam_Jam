using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {

    public float Startup_Spawner = 1.0f;
    public float Cooldown_Spawner = 1.0f;

    public float topScreen;
    public float bottomScreen;

    public GameObject[] enemies;

    private Enemy_WaveController EnemyMovement_WaveController;

    void Awake () {
        GameObject SpawnerController = GameObject.Find("SpawnerController");
        EnemyMovement_WaveController = SpawnerController.GetComponent<Enemy_WaveController>();
	}

    void Start()
    {
        InvokeRepeating("SpawnBois", Startup_Spawner, Cooldown_Spawner);
    }

    void Update () {

        

    }

    void SpawnBois()
    {
        if (EnemyMovement_WaveController.spawnCount > 0)
        {
            int enemyIndex = Random.Range(0, enemies.Length);
            Debug.Log(enemyIndex);

            Vector3 spawnSpot = new Vector3(transform.position.x, Random.Range(bottomScreen,topScreen), 0f);
            Instantiate(enemies[enemyIndex], spawnSpot, transform.rotation);
            EnemyMovement_WaveController.spawnCount -= 1;
        }
    }
}
