using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class progressbar : MonoBehaviour {

	private AudioSource audiosource;
	private float songLen;
	public Image foregroundImage;

	void Start ()
	{
		audiosource = GetComponent<AudioSource> ();
		songLen = audiosource.clip.length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		foregroundImage.fillAmount = audiosource.time / songLen;
	}
}
