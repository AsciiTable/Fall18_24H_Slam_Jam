using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Magenta : MonoBehaviour {

    private Transform tran_EnemyM;
    public Transform tran_Player;
    public float speed_EnemyM = 8;
    public float targetOffset_EnemyM = 30;

	void Awake () {
        GameObject Player = GameObject.Find("Player");
        tran_Player = Player.GetComponent<Transform>();
        tran_EnemyM = GetComponent<Transform>();
    }
	
	void Update () {
    /*    Movement    */
        tran_EnemyM.Translate(Vector3.right * Time.deltaTime * speed_EnemyM);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        /*    Bounce    */
        if (col.gameObject.tag == "Border")
        {
            Vector3 dir = tran_Player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.eulerAngles = transform.eulerAngles + new Vector3(0,0,(Random.Range(-1, 1) * targetOffset_EnemyM));
        }
    }
}
