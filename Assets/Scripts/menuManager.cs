using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class menuManager : MonoBehaviour 
{
	public Image image;
	public float fade;
	private bool submenu;
	public GameObject button1;
	public GameObject button2;
	public GameObject back;

	void Start () {
		image.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
		image.CrossFadeAlpha (1f, fade, false);
		submenu = false;
	}

	public void NewGame()
	{
		if (!submenu) {
			submenu = true;
			button1.GetComponentInChildren<Text>().text = "Level 1";
			button2.GetComponentInChildren<Text>().text = "Level 2";
			back.SetActive(true);
		}
		else
			UnityEngine.SceneManagement.SceneManager.LoadScene ("lvl");
	}
	public void ExitGame()
	{
		if (!submenu)
			Application.Quit ();
		else
			UnityEngine.SceneManagement.SceneManager.LoadScene ("level0");
	}

	public void BackMenu()
	{
		submenu = false;
		button1.GetComponentInChildren<Text>().text = "Start Game";
		button2.GetComponentInChildren<Text>().text = "Exit Game";
		back.SetActive(false);
	}
}
