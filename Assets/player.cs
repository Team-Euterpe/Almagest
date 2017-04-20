using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	float speed = 2.0f;
	Vector3 pos;
	Transform tr;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		pos = transform.position;
		tr = transform;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("right") && tr.position == pos)
		{
			pos += Vector3.right;
		}
		else if (Input.GetKey("left") && tr.position == pos)
		{
			pos += Vector3.left;
		}
		else if (Input.GetKey("up") && tr.position == pos)
		{
			pos += Vector3.forward;
		}
		else if (Input.GetKey("down") && tr.position == pos)
		{
			pos += Vector3.back;
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}
}
