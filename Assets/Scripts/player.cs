using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class player : MonoBehaviour
{

  public float speed = 2.0f;

  public Vector2 pos { private get; set; }

  private Transform tr;
  private Rigidbody rb;
  //private Vector3 previousact;
  public List<string> cannotmove;
  private GameObject model;

  // Use this for initialization
  void Start() {
    model = GameObject.FindGameObjectWithTag("Player");
    cannotmove = new List<string>();
    tr = transform;
    resetPos();
  }

  // Update is called once per frame
  void Update() {
    if (tr.position.x == pos.x && tr.position.z == pos.y) {
      if (!cannotmove.Contains("colliderRight") && Input.GetKey("right")) {
        pos = new Vector2((float)Math.Round(pos.x + 1), pos.y);
      } else if (!cannotmove.Contains("colliderLeft") && Input.GetKey("left")) {
        pos = new Vector2((float)Math.Round(pos.x - 1), pos.y);
      } else if (!cannotmove.Contains("colliderFront") && Input.GetKey("up")) {
        pos = new Vector2(pos.x, (float)Math.Round(pos.y + 1));
      } else if (!cannotmove.Contains("colliderBack") && Input.GetKey("down")) {
        pos = new Vector2(pos.x, (float)Math.Round(pos.y - 1));
      }
      //previousact = transform.position;
    }
    if (Input.GetButton("Rewind")) {
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
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, transform.position.y, pos.y), Time.deltaTime * speed);
    if (transform.position.y < -20)
      this.GetComponent<gameOver>().GameOver();
  }

  public void resetPos() {
    pos = new Vector2(tr.position.x, tr.position.z);
  }

  //void OnCollisionEnter(Collision other) {
  /*
		GetComponent<Rigidbody>().MovePosition(transform.position);
		if (other.gameObject.CompareTag ("Wall")) {
			transform.position = previousact;
			pos = new Vector2 (previousact.x, previousact.z); 
		}
    */
  //}
}
