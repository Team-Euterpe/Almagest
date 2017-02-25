using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
  void Update() {
    var p = transform.position;
    if (Input.GetKeyDown("left"))
      p.x -= 1;
    if (Input.GetKeyDown("right"))
      p.x += 1;
    if (Input.GetKeyDown("up"))
      p.z += 1;
    if (Input.GetKeyDown("down"))
      p.z -= 1;
    transform.position = p;
  }
}