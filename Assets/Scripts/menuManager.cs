using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class menuManager : MonoBehaviour 
{
	public Image image;
	public float fade;

	void Start () {
		image.GetComponent<CanvasRenderer> ().SetAlpha (0.0f);
		image.CrossFadeAlpha (1f, fade, false);
	}

	public void NewGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("level0");
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
