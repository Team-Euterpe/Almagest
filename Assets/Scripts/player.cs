using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

  public float speed = 2.0f;
  public Vector2 pos {private get; set; }
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
    pos = new Vector2(tr.position.x, tr.position.z);
  }

  // Update is called once per frame
  void Update() {
    if (tr.position.x == pos.x && tr.position.z == pos.y) {
      if (!cannotmove.Contains("colliderRight") && Input.GetKey("right")) {
        pos += Vector2.right;
      } else if (!cannotmove.Contains("colliderLeft") && Input.GetKey("left")) {
        pos += Vector2.left;
      } else if (!cannotmove.Contains("colliderFront") && Input.GetKey("up")) {
        pos += Vector2.up;
      } else if (!cannotmove.Contains("colliderBack") && Input.GetKey("down")) {
        pos += Vector2.down;
      }
      //previousact = transform.position;
    }
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, transform.position.y, pos.y), Time.deltaTime * speed);
    if (transform.position.y < -20)
      this.GetComponent<gameOver>().GameOver();
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
