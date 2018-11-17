using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTear : MonoBehaviour
{

    public float scatter_Tear;
    public Transform tran_Player;
    public float speed_Tear = 8;

    private Transform tran_Tear;

    // Use this for initialization
    void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        tran_Player = Player.GetComponent<Transform>();
        tran_Tear = GetComponent<Transform>();
    }

    void Start()
    {

        Vector3 dir = tran_Player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, scatter_Tear);
    }

    // Update is called once per frame
    void Update()
    {
        tran_Tear.Translate(Vector3.right * Time.deltaTime * speed_Tear);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*    Destroy    */
        if (col.gameObject.tag == "Border")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
