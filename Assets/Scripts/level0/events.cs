using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class events : MonoBehaviour {

	private player player;
	public int Trigger;
	private gameLevel level;
	private float oldspeed;
	public GameObject cam;
	private Grayscale grayscalecontrol;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<player>();
		level = GameObject.FindGameObjectWithTag("Level").GetComponent<gameLevel>();
		oldspeed = player.speed;
		grayscalecontrol = cam.GetComponent<Grayscale> ();
		grayscalecontrol.rampOffset = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (level.Beat < Trigger) {
			player.speed = 0.001f;
			grayscalecontrol.rampOffset = grayscalecontrol.rampOffset + 0.0157f;
		} else {
			player.speed = oldspeed;
			grayscalecontrol.rampOffset = 0;
			grayscalecontrol.enabled = false;
		}
	}
}
