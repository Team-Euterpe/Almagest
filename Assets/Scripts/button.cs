using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	public bool activated { get; private set; }
	private AudioSource[] fxs;

	// Use this for initialization
	void Start () {
		activated = false;
		fxs = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (!other.CompareTag ("Wall")) {
			fxs[0].Play ();
			activated = true;
		}
	}
	void OnTriggerExit (Collider other) {
		if (!other.CompareTag ("Wall")) {
			fxs[1].Play ();
			activated = false;
		}
	}
}
