using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
	  winText.text = $"Level complete!";
      Instantiate(winParticle, transform.position, winParticle.transform.rotation);
      level = GameObject.FindGameObjectWithTag("Level");
      level.GetComponent<gameLevel>().DeathCamera();
      other.gameObject.SetActive(false);
	  GameObject.FindGameObjectWithTag ("Unlock").GetComponent<unlock> ().SetUnlock (SceneManager.GetActiveScene ().name);
    }
  }
}
