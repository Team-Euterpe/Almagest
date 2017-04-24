using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCollision : MonoBehaviour {

  void OnTriggerEnter(Collider c) {
    if (c.gameObject.CompareTag("Wall")) {
      transform.parent.gameObject.GetComponent<player>().cannotmove.Add(name);
    }
      
  }
  void OnTriggerExit(Collider c) {
    if (c.gameObject.CompareTag("Wall"))
      transform.parent.gameObject.GetComponent<player>().cannotmove.Remove(name);
  }
}
