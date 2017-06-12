using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class particles : MonoBehaviour {

	private gameLevel level;
	public int Trigger;
	private bool triggered;

	void Awake()
	{
		level = GameObject.FindGameObjectWithTag("Level").GetComponent<gameLevel>();
		triggered = false;
	}

	void Update () 
	{
		if (level.Beat >= Trigger && !triggered) 
		{
			this.gameObject.GetComponent<ParticleSystem> ().Play ();
			triggered = true;
		}
	}
}
