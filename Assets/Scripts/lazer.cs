using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour {

	private GameObject player;
	private AudioSource fx;
	public float volume_ratio = 0f;
	private GameObject ray;
	private beatObject bo;
	private bool active;
	public int range;

	// Use this for initialization
	void Start () {
		fx = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
		bo = GetComponent<beatObject>();
		active = false;
		ray = transform.GetChild (0).gameObject;
		ray.transform.localPosition = new Vector3(0, 0, range);
		ray.transform.localScale = new Vector3(ray.transform.localScale.x, range, ray.transform.localScale.z);
		InvokeRepeating ("Fire", bo.offset, bo.rate);
	}
	
	// Update is called once per frame
	void Update () {
		float vol = Vector3.Distance(player.transform.position, transform.position) / volume_ratio;
		if (vol > 1.0)
			fx.volume = 0;
		else
			fx.volume = 1 - vol;
	}

	void Fire()
	{
		if (bo.active) 
		{
			if (!active) {
				active = true;
				ray.SetActive (true);
			} else {
				active = false;
				ray.SetActive (false);
			}
		}
	}
}
