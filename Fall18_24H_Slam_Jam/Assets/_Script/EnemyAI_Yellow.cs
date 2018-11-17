using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Yellow : MonoBehaviour {

    private Transform tran_EnemyY;
    public Transform tran_Player;
    public float speed_EnemyY = 1;

    void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        tran_Player = Player.GetComponent<Transform>();
        tran_EnemyY = GetComponent<Transform>();
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
    }

}
