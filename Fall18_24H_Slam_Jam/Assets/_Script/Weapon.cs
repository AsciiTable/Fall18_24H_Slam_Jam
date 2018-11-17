using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	public GameObject BulletTrailPrefab;
	private float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;
 
	private float timeToFire = 0;
	private Transform firePoint;

	// Use this for initialization
	void Awake ()
	{

		firePoint = transform.GetChild(0);

		firePoint = transform.Find("FirePoint");

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
		Audio.PlaySound("twinkle_shoot");
		
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
			Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);


		if (Time.time >= timeToSpawnEffect)
		{
			Effect();
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}
	
		//Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
		
		if (hit.collider != null)
		{
			//Debug.DrawLine(firePointPosition, hit.point, Color.red);
			Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage");
		}
	}

	void Effect()
	{
		GameObject go = GameObject.Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);//* Quaternion.Euler(0f,0f,180f)
		//go.transform.localRotation = Quaternion.Euler()
//		//subtracting the position of the player from the mouse position
//		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
//		//normalizing the vector meaning that all the sum of the vector will be equal to 1
//		difference.Normalize();
//		//find the angle in degrees
//		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
//		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
		
//			(playerMovement.facingRight) ? firePoint.rotation : 
//				Quaternion.Euler(0f,0f,180f) *firePoint.rotation);
		MoveBulletTrail bullet = go.GetComponent<MoveBulletTrail>();
		bullet.velocity = firePoint.right * ((playerMovement.facingRight) ? 1 : -1);
	}
	
	
}
