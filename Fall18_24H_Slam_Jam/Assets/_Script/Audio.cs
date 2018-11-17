using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

	public AudioClip JumpSFX;

	public AudioSource MusicSource;

	// Use this for initialization
	void Start ()
	{
		MusicSource.clip = JumpSFX;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			MusicSource.Play();
		}
	}
}
