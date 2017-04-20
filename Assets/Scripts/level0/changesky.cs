using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesky : MonoBehaviour {

	private gameLevel level;
	public int Trigger;
	public Material skybox;

	void Awake()
	{
		level = GameObject.FindGameObjectWithTag("Level").GetComponent<gameLevel>();
	}

	void Update () 
	{
		if (level.Beat >= Trigger) 
		{
			RenderSettings.skybox = skybox;
		}
	}
}
