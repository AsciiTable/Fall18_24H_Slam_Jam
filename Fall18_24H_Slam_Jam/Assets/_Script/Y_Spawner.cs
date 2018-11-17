using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_Spawner : MonoBehaviour {

    public float Startup_Spawner = 1.0f;
    public float Cooldown_Spawner = 1.0f;

    public float topScreen;
    public float bottomScreen;

    public GameObject Yellow_Enemy;

    private Enemy_WaveController EnemyMovement_WaveController;

    void Awake()
    {
        GameObject SpawnerController = GameObject.Find("SpawnerController");
        EnemyMovement_WaveController = SpawnerController.GetComponent<Enemy_WaveController>();
    }

    void Start()
    {
        InvokeRepeating("SpawnBois", Startup_Spawner, Cooldown_Spawner);
    }

    void SpawnBois()
    {
        
    if (EnemyMovement_WaveController.Yellows < EnemyMovement_WaveController.max_Y)
        {
            Vector3 spawnSpot = new Vector3(transform.position.x, Random.Range(bottomScreen, topScreen), 0f);
            Instantiate(Yellow_Enemy, spawnSpot, transform.rotation);
            EnemyMovement_WaveController.Yellows++;
        }
    }
}
