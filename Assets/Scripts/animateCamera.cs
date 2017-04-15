using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateCamera : MonoBehaviour {

	void Update () 
	{
		transform.Rotate (new Vector3 (0, -0.02f, 0.001f));
	}
}
