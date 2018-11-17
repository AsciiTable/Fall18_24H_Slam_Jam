using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask notToHit;

	private float timeToFire = 0;
	private Transform firePoint;

	// Use this for initialization
	void Awake ()
	{
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null)
		{
			Debug.LogError("No firepoint? NANIII??");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		}
		else
		{
			if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
			{
				timeToFire = Time.time + 1 / fireRate;
				Shoot();
			}
		}
	}

	void Shoot()
	{
		Debug.Log("Test");
	}
}
