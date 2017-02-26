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
}
