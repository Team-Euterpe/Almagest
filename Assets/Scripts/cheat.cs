using UnityEngine;
using UnityEngine.SceneManagement;
using Chronos;

public class cheat : MonoBehaviour
{
	public GameObject player;

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.R))
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    if (Input.GetKeyDown(KeyCode.Space)) {
      Timekeeper.instance.Clock("Root").localTimeScale = -1;
      this.gameObject.GetComponent<AudioSource>().pitch = -1;
    }
    if (Input.GetKeyUp(KeyCode.Space)) {
      Timekeeper.instance.Clock("Root").localTimeScale = 1;
      this.gameObject.GetComponent<AudioSource>().pitch = 1;
      foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
        player.GetComponent<player>().resetPos();
      }
    }
		if (Input.GetKeyDown (KeyCode.Keypad5)) {
			player.transform.position = new Vector3 (-7, 1, 103);
			player.GetComponent<player> ().resetPos ();
		}
  }
}
