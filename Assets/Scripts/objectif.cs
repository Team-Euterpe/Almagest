using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectif : MonoBehaviour
{

  public Text winText;
  public GameObject winParticle;
  GameObject level;
  void Start() {
    winText.text = "";
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")) {
      winText.text = "You win";
      Instantiate(winParticle, transform.position, winParticle.transform.rotation);
      level = GameObject.FindGameObjectWithTag("Level");
      level.GetComponent<gameLevel>().DeathCamera();
      other.gameObject.SetActive(false);
    }
  }
}
