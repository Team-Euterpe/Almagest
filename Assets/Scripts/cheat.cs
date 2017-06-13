using UnityEngine;

public class cheat : MonoBehaviour
{
  public GameObject player;

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Keypad1)) {
      player.transform.position = new Vector3(0, 1, 7);
      player.GetComponent<player>().resetPos();
    }
    if (Input.GetKeyDown(KeyCode.Keypad2)) {
      player.transform.position = new Vector3(-5, 1, 26);
      player.GetComponent<player>().resetPos();
    }
    if (Input.GetKeyDown(KeyCode.Keypad3)) {
      player.transform.position = new Vector3(-4, 4, 56);
      player.GetComponent<player>().resetPos();
    }
    if (Input.GetKeyDown(KeyCode.Keypad4)) {
      player.transform.position = new Vector3(-3, 4, 98);
      player.GetComponent<player>().resetPos();
    }
    if (Input.GetKeyDown(KeyCode.Keypad5)) {
      player.transform.position = new Vector3(-7, 1, 103);
      player.GetComponent<player>().resetPos();
    }
    if (Input.GetKeyDown(KeyCode.Keypad6)) {
      player.transform.position = new Vector3(-17, 1, 114);
      player.GetComponent<player>().resetPos();
    }
	if (Input.GetKeyDown(KeyCode.Keypad7)) {
	  player.transform.position = new Vector3(-17, 1, 122);
	  player.GetComponent<player>().resetPos();
	}
	if (Input.GetKeyDown(KeyCode.Keypad8)) {
	  player.transform.position = new Vector3(-17, 7, 137);
	  player.GetComponent<player>().resetPos();
	}
  }
}
