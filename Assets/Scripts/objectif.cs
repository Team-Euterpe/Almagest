using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectif : MonoBehaviour {

	public Text winText;

	void Start()
	{
		winText.text = "";
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			winText.text = "You win";
            other.gameObject.SetActive(false);
        }
    }
}
