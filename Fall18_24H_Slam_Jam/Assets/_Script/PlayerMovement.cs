﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public static PlayerMovement instance;
	public Rigidbody2D myRigid;

	private float xMove;
	private float yMove;
	public float speed = 10;

	public bool facingRight = true;
	
	
	// Update is called once per frame
	void Update()
	{
		playerController();
	}
	
	
	void playerController()
	{
		//This will get the input of the player based
		//on what key is pressed and how hard it is pressed
		//it will then store the value into xMove
		xMove = Input.GetAxis("Horizontal")*speed;
		yMove = Input.GetAxis("Vertical") * speed;

		if (xMove < 0 && facingRight)
		{
			Flip();
		}
		else if (xMove > 0 && !facingRight)
		{
			Flip();
		}
		
		
		//This lets you access the velocity vector of the rigidbody 
		//and give it values based on the buttons pressed (x and y values)
		myRigid.velocity = new Vector2(xMove, yMove);
		
		
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
