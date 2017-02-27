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
	public float volume_ratio = 0f;
	private float rate;
  public List<float> range_start;
  public List<float> range_stop;
  private bool active = true;
  private GameObject levelObject;
  private gameLevel level;

	void Start () 
	{
		fx = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
    levelObject = GameObject.FindGameObjectWithTag("Level");
    level = levelObject.GetComponent<gameLevel>();
    BPM = level.BPM;
    rate = (60 / BPM) * divisor;
    InvokeRepeating("Fire", 0f, rate);
	}
	void Update ()
  {
   	float vol = Vector3.Distance (player.transform.position, transform.position) / volume_ratio;
		if (vol > 1.0)
			fx.volume = 0;
		else
			fx.volume = 1 - vol;
    if (range_stop.Count != 0 && active) {
      if (range_stop[0] > level.Beat) {
        range_stop.RemoveAt(0);
        active = false;
      }
    }
    if (range_start.Count != 0 && !active) {
      if (range_start[0] > level.Beat) {
        range_start.RemoveAt(0);
        active = true;
      }
    }
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
