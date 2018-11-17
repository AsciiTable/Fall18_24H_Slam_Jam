using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Spawner : MonoBehaviour
{

    public float Startup_Spawner = 1.0f;
    public float Cooldown_Spawner = 1.0f;

    public float topScreen;
    public float bottomScreen;

    public GameObject Magenta_Enemy;

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

        if (EnemyMovement_WaveController.Magentas < EnemyMovement_WaveController.max_M)
        {
            Vector3 spawnSpot = new Vector3(transform.position.x, Random.Range(bottomScreen, topScreen), 0f);
            Instantiate(Magenta_Enemy, spawnSpot, transform.rotation);
            EnemyMovement_WaveController.Magentas++;
        }
    }
}
