using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using Chronos;

public class gameLevel : MonoBehaviour
{

  public float BPM;

  public AudioSource music{ get; private set; }

  public GameObject playerCamera, deathCamera;

  public float Beat { get; private set; }

  void Start() {
    music = GetComponent<AudioSource>();
    music.Play();
    playerCamera.SetActive(true);
    deathCamera.SetActive(false);
  }

  void Update() {
    //Beat = Time.timeSinceLevelLoad / (60 / BPM);
    Beat = GetComponent<Timeline>().time / (60 / BPM);
    print(Beat);
    if (Input.GetButton("Fast retry"))
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	if (Input.GetButton("Main menu"))
	  SceneManager.LoadScene("mainmenu");
	if (GameObject.FindGameObjectsWithTag ("Player").Length != 0) {
		if (Input.GetButton ("Rewind")) {
			Timekeeper.instance.Clock ("Root").localTimeScale = -1;
			this.gameObject.GetComponent<AudioSource> ().pitch = -1;
		}
		if (Input.GetButtonUp ("Rewind")) {
			Timekeeper.instance.Clock ("Root").localTimeScale = 1;
			this.gameObject.GetComponent<AudioSource> ().pitch = 1;
			foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
				player.GetComponent<player> ().resetPos ();
				}
		}
	}
  }

  public void PitchOut(float timeOut) {
    StartCoroutine(PitchOutCoroutine(timeOut));
  }

  IEnumerator PitchOutCoroutine(float timeOut) {
    while (music.pitch > 0) {
      music.pitch -= 1f / 20f;
      yield return new WaitForSeconds(timeOut / 20);
    }
    music.Stop();
  }

  public void DeathCamera() {
    playerCamera.SetActive(false);
    deathCamera.SetActive(true);
  }
}
