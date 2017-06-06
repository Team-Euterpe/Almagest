using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {
	
	private bool onPlatform;
	private GameObject player;

	void Start () {
		onPlatform = false;
	}

	void Update () {
		if (onPlatform && !Input.GetKey("right") && !Input.GetKey("left") && !Input.GetKey("up") && !Input.GetKey("down")) {
				player.transform.position = this.GetComponent<Transform> ().position;
		}
		player.GetComponent<player> ().resetPos ();
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag("Player")) {
			onPlatform = true;
			player = c.gameObject;
		}
	}

	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.CompareTag ("Player")) {
			onPlatform = false;
		}
	}
}
