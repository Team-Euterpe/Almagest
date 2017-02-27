using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour {

	private float BPM = 0f;
	private float rate;
	public float divisor = 1f;
	private GameObject levelObject;
	private gameLevel level;
	private bool activate = false;
	// Use this for initialization
	void Start () 
	{
		levelObject = GameObject.FindGameObjectWithTag("Level");
		level = levelObject.GetComponent<gameLevel>();
		BPM = level.BPM;
		rate = (60 / BPM) * divisor;
		InvokeRepeating ("Gate", 0f, rate);

	}
	void OnTriggerStay (Collider other)
	{
		if (activate) 
		{
			if (other.gameObject.CompareTag ("Player")) {
				Rigidbody rigid = other.gameObject.GetComponent<Rigidbody> ();
				rigid.AddForce (transform.up * 300);
			}
		}
	}
	void Gate ()
	{
		activate = true;
		StartCoroutine (Wait ());
	}
	IEnumerator Wait()
	{
		yield return new WaitForSecondsRealtime(rate / 4);
		activate = false;
	}
}
