using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCollision : MonoBehaviour {

  void OnTriggerEnter(Collider c) {
    Debug.Log(c.tag);
    if (c.gameObject.CompareTag("Wall")) {
      transform.parent.gameObject.GetComponent<player>().cannotmove.Add(this.name);
      Debug.Log("a wall !");
    }
      
  }
  void OnTriggerExit(Collider c) {
    if (c.gameObject.CompareTag("Wall"))
      transform.parent.gameObject.GetComponent<player>().cannotmove.Remove(this.name);
  }
}
