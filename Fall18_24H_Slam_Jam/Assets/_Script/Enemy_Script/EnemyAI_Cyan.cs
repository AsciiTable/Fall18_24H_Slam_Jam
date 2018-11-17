using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Cyan : MonoBehaviour
{

    private Transform tran_EnemyC;
    public Transform tran_Player;

    public GameObject deathTear_1;
    public GameObject deathTear_2;
    public GameObject deathTear_3;

    public float tearCooldown_EnemyC = 5;
    public float speed_EnemyC = 5;
    public PlayerCollisions PlayerCollisions_C;

    void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        tran_Player = Player.GetComponent<Transform>();
        tran_EnemyC = GetComponent<Transform>();
        PlayerCollisions_C = Player.GetComponent<PlayerCollisions>();

        /*  Tears   */
        InvokeRepeating("SpawnTears", tearCooldown_EnemyC, tearCooldown_EnemyC);
    }

    void Update()
    {
        /*    Movement    */
        tran_EnemyC.Translate(Vector3.right * Time.deltaTime * speed_EnemyC);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*    Patrol    */
        if (col.gameObject.tag == "Border")
        {
            tran_EnemyC.Rotate(Vector3.forward * 180f);
        }

        if (col.gameObject.tag == "Weapon" && PlayerCollisions_C.Gun_Color == 2)
        {
            Destroy(gameObject);
            if (PlayerCollisions_C.Cyan_Bar < PlayerCollisions_C.Cyan_Max)
            {
                PlayerCollisions_C.Cyan_Bar++;
            }
        }
    }

    void SpawnTears()
    {
        Audio.PlaySound("8BIT_RETRO_Hit_Bump_Thump_mono");
        Instantiate(deathTear_1, transform.position, transform.rotation);
        Instantiate(deathTear_2, transform.position, transform.rotation);
        Instantiate(deathTear_3, transform.position, transform.rotation);
    }
}
