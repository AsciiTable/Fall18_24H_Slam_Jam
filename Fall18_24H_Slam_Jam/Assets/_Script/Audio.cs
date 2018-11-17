﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

	public static  AudioClip EnemyBumpSFX;

	public static AudioClip EnemyShootSFX;

	static AudioSource MusicSource;

	// Use this for initialization
	void Start ()
	{
		EnemyBumpSFX = Resources.Load<AudioClip>("8BIT_RETRO_Hit_Bump_Thump_mono");
		MusicSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void PlaySound(string clip)
	{
		switch (clip)
		{
			case "8BIT_RETRO_Hit_Bump_Thump_mono":
				MusicSource.PlayOneShot(EnemyBumpSFX);
				break;
			default:
				break;
		}


	}
}
