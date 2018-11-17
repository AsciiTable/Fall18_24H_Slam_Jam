using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_HeartBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    private void onTriggerEnter2D(Collider col)
    {
        if(col.gameObject.tag == "Deathness" || col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
