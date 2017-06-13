using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour {

	public bool level1 { get; private set; }
	public bool level2 { get; private set; }

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		level1 = false;
		level2 = false;
	}

	public void SetUnlock(string scene)
	{
		print (scene);
		if (scene == "lvl")
			level1 = true;
		if (scene == "level0")
			level2 = true;
	}
}
