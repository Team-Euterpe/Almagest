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
	public float speed;
	private float speedcalc;
	private GameObject level;

	// Use this for initialization
	void Start () {
		origPos = transform.position;
		destPos = new Vector3 (destX, destY, destZ);
		goingBack = false;
		level = GameObject.FindGameObjectWithTag ("Level");
		speedcalc = (Mathf.Abs (Vector3.Distance (origPos, destPos)) / (60 / level.GetComponent<gameLevel> ().BPM)) / speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == destPos)
			goingBack = true;
		if (transform.position == origPos)
			goingBack = false;
		if (goingBack)
			transform.position = Vector3.MoveTowards (transform.position, origPos, Time.deltaTime * speedcalc);
		else
			transform.position = Vector3.MoveTowards (transform.position, destPos, Time.deltaTime * speedcalc);
	}
}
