using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class menuManager : MonoBehaviour 
{
	public void NewGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("crashtest");
	}
	public void ExitGame()
	{
		Application.Quit ();
	}
}
