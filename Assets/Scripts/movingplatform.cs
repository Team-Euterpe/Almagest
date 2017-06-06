using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour {

	public float destX;
	public float destY;
	public float destZ;
	private Vector3 origPos;
	private Vector3 destPos;
	private bool goingBack;

	// Use this for initialization
	void Start () {
		origPos = transform.position;
		destPos = new Vector3 (destX, destY, destZ);
		goingBack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == destPos)
			goingBack = true;
		if (transform.position == origPos)
			goingBack = false;
		if (goingBack)
			transform.position = Vector3.MoveTowards (transform.position, origPos, Time.deltaTime);
		else
			transform.position = Vector3.MoveTowards (transform.position, destPos, Time.deltaTime);
	}
}
