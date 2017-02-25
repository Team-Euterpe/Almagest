using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {

	public GameObject barrel;
	public GameObject projectile;
	public float time = 0f;
	public float force = 0f;
	public float BPM = 0f;
	private float rate;

	void Start () 
	{
		rate = 60 / BPM;
		InvokeRepeating ("Fire", 0f, rate);
	}
	void Fire()
	{
		GameObject temp_barrel = Instantiate (projectile, barrel.transform.position, projectile.transform.rotation);
		Rigidbody temp_rigidbody = temp_barrel.GetComponent<Rigidbody> ();
		temp_rigidbody.AddForce (transform.forward * force);
		Destroy (temp_barrel, time);
	}
}
