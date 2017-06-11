using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

	public bool activated { get; private set; }
	private AudioSource fx;

	// Use this for initialization
	void Start () {
		activated = false;
		fx = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {
		if (!other.CompareTag("Wall"))
			activated = true;
	}
	void OnTriggerExit (Collider other) {
		if (!other.CompareTag("Wall"))
			activated = false;
	}
}
