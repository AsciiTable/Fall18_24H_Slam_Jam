using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody2D myRigid;

	private float xMove;
	private float yMove;
	public float speed = 10;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerController();
	}

	void playerController()
	{
		//This will get the input of the player based
		//on what key is pressed and how hard it is pressed
		//it will then store the value into xMove
		xMove = Input.GetAxis("Horizontal")*speed;
		yMove = Input.GetAxis("Vertical") * speed;

		//This lets you access the velocity vector of the rigidbody 
		//and give it values based on the buttons pressed (x and y values)
		myRigid.velocity = new Vector2(xMove, yMove);
		

	}
}
