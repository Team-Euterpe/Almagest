using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectif : MonoBehaviour {

	public Text winText;
	public GameObject winParticle;

	void Start()
	{
		winText.text = "";
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			winText.text = "You win";
			Instantiate (winParticle, this.transform.position, winParticle.transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}
