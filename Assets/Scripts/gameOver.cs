using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

	public GameObject loseParticle;
	public Text loseText;

	public void GameOver()
	{
		GameObject.FindGameObjectWithTag("Level").GetComponent<gameLevel>().music.Stop();
		loseText.text = "You died";
		Instantiate (loseParticle, this.transform.position, loseParticle.transform.rotation);
		this.gameObject.SetActive (false);
	}
}
