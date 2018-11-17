using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletTrail : MonoBehaviour
{
	public float fireDirection = 1f;
	public int moveSpeed = 230;
	public Vector3 velocity;

//	void Start()
//	{
//		if (fireDirection == Vector3.zero)
//		{
//			//fireDirection = transform.right;
//		}
//	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(velocity * Time.deltaTime * moveSpeed);
		Destroy(gameObject, 1);
	}
}
