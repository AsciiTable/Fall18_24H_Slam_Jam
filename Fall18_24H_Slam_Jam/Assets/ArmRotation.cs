using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
	public PlayerMovement playerMove;
	public int rotationOffset = 0;
 
	
	// Update is called once per frame
	void Update ()
	{
		//subtracting the position of the player from the mouse position
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		
		//normalizing the vector meaning that all the sum of the vector will be equal to 1
		difference.Normalize();
		
		//find the angle in degrees
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ 
		                                              + rotationOffset 
													   + ((playerMove.facingRight)? 0 : -180f));
	}
}
