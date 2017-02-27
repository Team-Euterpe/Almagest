using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectif : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("You win");
            other.gameObject.SetActive(false);
        }
    }
}
