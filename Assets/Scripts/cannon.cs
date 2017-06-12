using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class cannon : MonoBehaviour
{

  public GameObject barrel;
  public GameObject projectile;
  private GameObject player;
  private AudioSource fx;
  public float time = 0f;
  public float force = 0f;
  public float volume_ratio = 0f;
  private beatObject bo;

  void Start() {
    fx = GetComponent<AudioSource>();
    player = GameObject.FindGameObjectWithTag("Player");
    bo = GetComponent<beatObject>();
	//StartCoroutine (Fire());
	InvokeRepeating("Fire2", bo.offset, bo.rate);
  }

  void Update() {
    float vol = Vector3.Distance(player.transform.position, transform.position) / volume_ratio;
    if (vol > 1.0)
      fx.volume = 0;
    else
      fx.volume = 1 - vol;
  }

  IEnumerator Fire() {
		yield return GetComponent<Timeline> ().WaitForSeconds (bo.offset);
		while (true) {
			if (bo.active) {
				fx.Play ();
				/*
				GameObject temp_barrel = Instantiate(projectile, barrel.transform.position, projectile.transform.rotation);
				Rigidbody temp_rigidbody = temp_barrel.GetComponent<Rigidbody> ();
				temp_rigidbody.GetComponent<Timeline> ().rigidbody.AddForce (transform.forward * force);
				Destroy (temp_barrel, time);
				*/
				GetComponent<Timeline> ().Do (true, delegate() {
					GameObject temp_barrel = Instantiate (projectile, barrel.transform.position, projectile.transform.rotation);
					Rigidbody temp_rigidbody = temp_barrel.GetComponent<Rigidbody> ();
					temp_rigidbody.GetComponent<Timeline> ().rigidbody.AddForce (transform.forward * force);
					StartCoroutine(Wait(time));
					//Destroy (temp_barrel, time);
					temp_barrel.SetActive(false);
					return temp_barrel;
				}, 
					delegate(GameObject temp_barrel) {
						temp_barrel.SetActive(true);
						Destroy (temp_barrel);
					}
				);
			}
			yield return GetComponent<Timeline> ().WaitForSeconds (bo.rate);
		}
	}

	IEnumerator Wait(float time){
		yield return GetComponent<Timeline> ().WaitForSeconds (time);
	}

	void Fire2()
	{
		if (bo.active) {
			fx.Play ();
			GameObject temp_barrel = Instantiate (projectile, barrel.transform.position, projectile.transform.rotation);
			Rigidbody temp_rigidbody = temp_barrel.GetComponent<Rigidbody> ();
			temp_rigidbody.GetComponent<Timeline> ().rigidbody.AddForce (transform.forward * force);
			Destroy (temp_barrel, time);
		}
	}
}
