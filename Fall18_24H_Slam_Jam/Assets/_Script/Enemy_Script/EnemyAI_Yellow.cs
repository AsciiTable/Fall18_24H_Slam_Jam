using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Yellow : MonoBehaviour {

    private Transform tran_EnemyY;
    public Transform tran_Player;
    public float speed_EnemyY = 1;
    public PlayerCollisions PlayerCollisions_Y;

    public SpriteRenderer SpriteRenderer_Y;

    void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        tran_Player = Player.GetComponent<Transform>();
        tran_EnemyY = GetComponent<Transform>();
        SpriteRenderer_Y = GetComponent<SpriteRenderer>();

        PlayerCollisions_Y = Player.GetComponent<PlayerCollisions>();
    }

    void Update()
    {
        /*    Movement    */
        tran_EnemyY.Translate(Vector3.right * Time.deltaTime * speed_EnemyY);

        /*    Look at Player    */
        Vector3 dir = tran_Player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.eulerAngles = transform.eulerAngles;

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            SpriteRenderer_Y.flipY = true;
            SpriteRenderer_Y.flipX = true;

        }
        else
        {
            SpriteRenderer_Y.flipY = false;
            SpriteRenderer_Y.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weapon" )
        {
            Destroy(gameObject);
            if (PlayerCollisions_Y.Yellow_Bar < PlayerCollisions_Y.Yellow_Max)
            {
                PlayerCollisions_Y.Yellow_Bar++;
            }
        }
    }

}
