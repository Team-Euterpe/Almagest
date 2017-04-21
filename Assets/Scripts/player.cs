using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

  public float speed = 2.0f;
  private Vector2 pos;
  private Transform tr;
  private Rigidbody rb;
  private Vector3 previousact;

  // Use this for initialization
  void Start() {
    tr = transform;
    pos = new Vector2(tr.position.x, tr.position.z);
  }

  // Update is called once per frame
  void Update() {
		if (tr.position.x == pos.x && tr.position.z == pos.y) {
			if (Input.GetKey ("right")) {
				pos += Vector2.right;
			} else if (Input.GetKey ("left")) {
				pos += Vector2.left;
			} else if (Input.GetKey ("up")) {
				pos += Vector2.up;
			} else if (Input.GetKey ("down")) {
				pos += Vector2.down;
			}
			previousact = transform.position;
		}
		transform.position = Vector3.MoveTowards (transform.position, new Vector3 (pos.x, transform.position.y, pos.y), Time.deltaTime * speed);
	if (transform.position.y < -20)
		this.GetComponent<gameOver>().GameOver();
  }
	void OnCollisionEnter(Collision other)
	{
		GetComponent<Rigidbody>().MovePosition(transform.position);
		if (other.gameObject.CompareTag ("RealWall")) {
			transform.position = previousact;
			pos = new Vector2 (previousact.x, previousact.z); 
		}
	}
}
