using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

    private Transform tran_Enemy;
    public Transform tran_Player;
    public float speed_Enemy = 15;
    public float targetOffset_Enemy = 30;

	void Awake () {
        tran_Enemy = GetComponent<Transform>();
	}
	
	void Update () {
    /*    Movement    */
        tran_Enemy.Translate(Vector3.right * Time.deltaTime * speed_Enemy);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        /*    Bounce    */
        if (col.gameObject.tag == "Border")
        {
            Vector3 dir = tran_Player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.eulerAngles = transform.eulerAngles + new Vector3(0,0,(Random.Range(-1, 1) * targetOffset_Enemy));
        }
    }
}
