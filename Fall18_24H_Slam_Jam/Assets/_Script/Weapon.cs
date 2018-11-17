using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	private float timeToFire = 0;
	private Transform firePoint;

	// Use this for initialization
	void Awake ()
	{
<<<<<<< HEAD
		firePoint = transform.GetChild(0);
=======
		firePoint = transform.Find("FirePoint");
>>>>>>> a25557c90e938c77d229727e6ed7e31bbb536b48
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
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
			Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		
		Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
		
		if (hit.collider != null)
		{
			Debug.DrawLine(firePointPosition, hit.point, Color.red);
			Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage");
		}
	}
}
