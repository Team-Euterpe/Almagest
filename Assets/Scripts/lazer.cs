using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode {Periodic, Nonperiodic, Button}

public class lazer : MonoBehaviour {

	private GameObject player;
	private AudioSource fx;
	public float volume_ratio = 0f;
	private GameObject ray;
	private beatObject bo;
	private bool active;
	public int range;
	public Mode activation;
	public GameObject button;
	private button but;

	// Use this for initialization
	void Start () {
		fx = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag("Player");
		bo = GetComponent<beatObject>();
		active = false;
		but = button.GetComponent<button> ();
		ray = transform.GetChild (0).gameObject;
		ray.transform.localPosition = new Vector3(0, 0, range);
		ray.transform.localScale = new Vector3(ray.transform.localScale.x, range, ray.transform.localScale.z);
		if (activation != Mode.Button)
			InvokeRepeating ("Fire", bo.offset, bo.rate);
	}
	
	// Update is called once per frame
	void Update () {
		float vol = Vector3.Distance(player.transform.position, transform.position) / volume_ratio;
		if (vol > 1.0)
			fx.volume = 0;
		else
			fx.volume = 1 - vol;
		if (activation == Mode.Button) {
			if (!active && !but.activated) {
				fx.Play ();
				active = true;
				ray.SetActive (true);
			} else if (active && but.activated) {
				fx.Stop ();
				active = false;
				ray.SetActive (false);
			}
		}
	}

	void Fire()
	{
		if (bo.active) {
			if (!active) 
			{
				fx.Play ();
				active = true;
				ray.SetActive (true);
			} 
			else 
			{
				if (activation == Mode.Periodic) 
				{
					fx.Stop ();
					active = false;
					ray.SetActive (false);
				}
			}
		} else {
			if (active) {
				if (activation == Mode.Nonperiodic) {
					fx.Stop ();
					active = false;
					ray.SetActive (false);
				}
			}
		}
	}
}
