using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	public GameObject loseParticle;
	public Text loseText;

  const float timeToDie = 6.28f;

	public void GameOver()
	{
    GameObject.FindGameObjectWithTag("Level").GetComponent<gameLevel>().PitchOut(timeToDie);
		loseText.text = "You died";
		Instantiate (loseParticle, transform.position, loseParticle.transform.rotation);
		gameObject.SetActive (false);
	}
}
