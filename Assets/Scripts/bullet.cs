﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			other.gameObject.GetComponent<gameOver>().GameOver();
		}
	}
}
