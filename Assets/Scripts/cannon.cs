using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bo = GetComponent<beatObject>();
    fx = GetComponent<AudioSource>();
    player = GameObject.FindGameObjectWithTag("Player");
    InvokeRepeating("Fire", 0f, bo.rate);
  }

  void Update() {
    float vol = Vector3.Distance(player.transform.position, transform.position) / volume_ratio;
    if (vol > 1.0)
      fx.volume = 0;
    else
      fx.volume = 1 - vol;
  }

  void Fire() {
    if (bo.active) {
      fx.Play();
      GameObject temp_barrel = Instantiate(projectile, barrel.transform.position, projectile.transform.rotation);
      Rigidbody temp_rigidbody = temp_barrel.GetComponent<Rigidbody>();
      temp_rigidbody.AddForce(transform.forward * force);
      Destroy(temp_barrel, time);
    }
  }
}
