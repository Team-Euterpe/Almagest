using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public float x;
	public float y;
	public float z;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			this.gameObject.GetComponent<AudioSource> ().Play ();
			other.gameObject.transform.position = new Vector3 (x, y, z);
			other.gameObject.GetComponent<player> ().pos = new Vector2 (x, z);
		}
	}
}
