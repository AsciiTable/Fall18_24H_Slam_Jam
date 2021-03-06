﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Magenta : MonoBehaviour {

    private Transform tran_EnemyM;
    public Transform tran_Player;
    public float speed_EnemyM = 8;
    public float targetOffset_EnemyM = 30;

    public SpriteRenderer SpriteRenderer_M;

    public PlayerCollisions PlayerCollisions_M;
    public Enemy_WaveController Wave_M;


    void Awake () {
        GameObject Player = GameObject.Find("Player");
        tran_Player = Player.GetComponent<Transform>();
        tran_EnemyM = GetComponent<Transform>();
        PlayerCollisions_M = GetComponent<PlayerCollisions>();
        SpriteRenderer_M = GetComponent<SpriteRenderer>();

        GameObject Spawner_M = GameObject.Find("SpawnerController");
        Wave_M = Spawner_M.GetComponent<Enemy_WaveController>();
    }
	
	void Update () {
    /*    Movement    */
        tran_EnemyM.Translate(Vector3.right * Time.deltaTime * speed_EnemyM);

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            SpriteRenderer_M.flipY = true;
            SpriteRenderer_M.flipX = true;

        }
        else
        {
            SpriteRenderer_M.flipY = false;
            SpriteRenderer_M.flipX = true;
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        /*    Bounce    */
        if (col.gameObject.tag == "Border")
        {
            Vector3 dir = tran_Player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.eulerAngles = transform.eulerAngles + new Vector3(0,0,(Random.Range(-1, 1) * targetOffset_EnemyM));
        }

        if (col.gameObject.tag == "Weapon")
        {
            Wave_M.Magentas -= 1;
            Destroy(gameObject);


            /*
            if (PlayerCollisions_M.Magenta_Bar < PlayerCollisions_M.Magenta_Max)
            {
                PlayerCollisions_M.Magenta_Bar++;
            }
            */

        }
    }
}
