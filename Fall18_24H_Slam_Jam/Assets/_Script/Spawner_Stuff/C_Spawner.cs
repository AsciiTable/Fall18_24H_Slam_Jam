using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Spawner : MonoBehaviour {

    public float Startup_Spawner = 1.0f;
    public float Cooldown_Spawner = 1.0f;

    public float topScreen;
    public float bottomScreen;

    public GameObject Cyan_Enemy;

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
        if (EnemyMovement_WaveController.Cyans < EnemyMovement_WaveController.max_C) {
            Vector3 spawnSpot = new Vector3(transform.position.x, Random.Range(bottomScreen, topScreen), 0f);
            EnemyMovement_WaveController.CyanTop = true;
                Instantiate(Cyan_Enemy, spawnSpot, transform.rotation);
            }
            EnemyMovement_WaveController.Cyans++;
        }
            
    }
