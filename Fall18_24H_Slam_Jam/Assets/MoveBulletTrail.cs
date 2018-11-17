using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletTrail : MonoBehaviour
{
	public float fireDirection = 1f;
	public int moveSpeed = 230;
	public Vector3 velocity;


	// Update is called once per frame
	void Update ()
	{
		transform.position += velocity * Time.deltaTime * moveSpeed;
		//transform.Translate(velocity * Time.deltaTime * moveSpeed);
		Destroy(gameObject, 1);
	}
}
