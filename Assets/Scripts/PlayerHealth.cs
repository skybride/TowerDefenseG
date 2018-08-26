using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] int health = 10;
	[SerializeField] int decreaseHealth = 1;
	[SerializeField] Text healthText;
	[SerializeField] AudioClip playerDamageSfx;

	void Start()
	{
		healthText.text = health.ToString ();
	}

	private void OnTriggerEnter(Collider other)
	{
		GetComponent<AudioSource> ().PlayOneShot (playerDamageSfx);
		health -= decreaseHealth;
		healthText.text = health.ToString ();
	}
}
