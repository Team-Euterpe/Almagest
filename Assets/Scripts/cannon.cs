using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {

	public GameObject barrel;
	public GameObject projectile;
	private GameObject player;
	private AudioSource fx;
	public float time = 0f;
  public float divisor = 1f;
	public float force = 0f;
	private float BPM = 0f;
	public float volume_ratio = 0;
	private float rate;
  private GameObject levelObject;
  private gameLevel level;

	void Start () 
  {
		fx = GetComponent<AudioSource>();
    levelObject = GameObject.FindGameObjectWithTag("Level");
    level = levelObject.GetComponent<gameLevel>();
    BPM = level.BPM;
    rate = (60 / BPM) * divisor;
    InvokeRepeating ("Fire", 0f, rate);
	}
	void Update ()
  {
    player = GameObject.FindGameObjectWithTag("Player");
		float vol = Vector3.Distance (player.transform.position, transform.position) / volume_ratio;
		if (vol > 1.0)
			fx.volume = 0;
		else
			fx.volume = 1 - vol;
	}
	void Fire()
	{
		fx.Play ();
		GameObject temp_barrel = Instantiate (projectile, barrel.transform.position, projectile.transform.rotation);
		Rigidbody temp_rigidbody = temp_barrel.GetComponent<Rigidbody> ();
		temp_rigidbody.AddForce (transform.forward * force);
		Destroy (temp_barrel, time);
	}
}
