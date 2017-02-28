using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLevel : MonoBehaviour
{

  public float BPM;

  public AudioSource music{ get; private set; }

  public float Beat { get; private set; }

  void Start() {
    music = GetComponent<AudioSource>();
    music.Play();
  }

  void Update() {
    Beat = (60 / BPM) * Time.timeSinceLevelLoad;
  }
  public void PitchOut(float timeOut) {
    StartCoroutine(PitchOutCoroutine(timeOut));
  }
  IEnumerator PitchOutCoroutine(float timeOut) {
    while (music.pitch > 0) {
      music.pitch -= 1f/20f;
      yield return new WaitForSeconds(timeOut / 20);
    }
    music.Stop();
  }
}
