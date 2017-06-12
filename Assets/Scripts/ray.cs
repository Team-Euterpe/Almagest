using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {


	private float range;
	private float orig_range;
	private bool box;

	void Start()
	{
		range = GetComponentInParent<lazer> ().range;
		orig_range = range;
		box = false;
	}

	/*
	private GameObject box;
	private bool isbox;

	void Start()
	{
		range = GetComponentInParent<lazer> ().range;
		isbox = false;
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
			other.gameObject.GetComponent<gameOver> ().GameOver ();
		else if (other.gameObject.CompareTag ("Box")) {
			box = other.gameObject;
			isbox = true;
		}
	}
	void Update()
	{
		if (isbox) {
			float distance = Mathf.Abs (Vector3.Distance (box.transform.position, GetComponentInParent<Transform> ().position)) / 1.5f;
			transform.localPosition = new Vector3 (0, 0, distance);
			transform.localScale = new Vector3 (transform.localScale.x, distance, transform.localScale.z);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == box) {
			//isbox = false;
			transform.localPosition = new Vector3(0, 0, range);
			transform.localScale = new Vector3(transform.localScale.x, range, transform.localScale.z);
		}
	}
*/

	void Update()
	{
		if (range > orig_range)
			range = orig_range;
		RaycastHit[] hits;
		box = false;
		hits = Physics.RaycastAll (transform.parent.position, transform.parent.forward, range);
		foreach (RaycastHit hit in hits) {
			if (hit.transform.gameObject.CompareTag ("Box")) {
				box = true;
				range = Mathf.Abs (Vector3.Distance (hit.transform.position, transform.parent.position));
				ReziveOut ();
			} else if (hit.transform.gameObject.CompareTag ("Player") && !box)
				hit.transform.gameObject.GetComponent<gameOver> ().GameOver ();
			if (box)
				break;
		}
		if (!box) {
			range = orig_range;
			print (range);
			ReziveOut ();
		}
	}

	void ReziveOut()
	{
		transform.localPosition = new Vector3 (0, 0, range);
		transform.localScale = new Vector3 (transform.localScale.x, range, transform.localScale.z);
	}
}
