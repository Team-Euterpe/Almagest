using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movie : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		MovieTexture movie = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		movie.loop = true;
		movie.Play();
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			Rigidbody rigid = other.gameObject.GetComponent<Rigidbody> ();
			rigid.AddForce (transform.up * 300);
		}
	}
}
