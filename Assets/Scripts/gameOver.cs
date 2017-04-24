using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	public GameObject loseParticle;
  GameObject level;
	public Text loseText;

  const float timeToDie = 6.28f;

	public void GameOver()
	{
    level = GameObject.FindGameObjectWithTag("Level");
    level.GetComponent<gameLevel>().PitchOut(timeToDie);
    level.GetComponent<gameLevel>().DeathCamera();
		loseText.text = "You died";
		Instantiate (loseParticle, transform.position, loseParticle.transform.rotation);
		gameObject.SetActive (false);
	}
}
