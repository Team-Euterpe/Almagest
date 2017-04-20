using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

  float speed = 2.0f;
  Vector2 pos;
  Transform tr;
  Rigidbody rb;

  // Use this for initialization
  void Start() {
    tr = transform;
    pos = new Vector2(tr.position.x, tr.position.z);
  }

  // Update is called once per frame
  void Update() {
    if (tr.position.x == pos.x && tr.position.z == pos.y) {
      if (Input.GetKey("right")) {
        pos += Vector2.right;
      } else if (Input.GetKey("left")) {
        pos += Vector2.left;
      } else if (Input.GetKey("up")) {
        pos += Vector2.up;
      } else if (Input.GetKey("down")) {
        pos += Vector2.down;
      }
    }
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, transform.position.y, pos.y), Time.deltaTime * speed);
  }
}
