using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLevel : MonoBehaviour {
  private AudioSource music;
  public float BPM;
  public float Beat { get; private set; }
	// Use this for initialization 
	void Start () {
    this.music = GetComponent<AudioSource>();
    music.Play();
	}
	
	// Update is called once per frame
	void Update () {
    Beat = (60 / BPM) * Time.time;
	}
}
