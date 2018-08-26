using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider collisionMesh;
	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem explode;
	[SerializeField] AudioClip enemyDamageSfx;
	[SerializeField] AudioClip enemyDeathSfx;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnParticleCollision(GameObject other)
	{
		print ("I'm hit! ");
		ProcessHit ();
		if (hitPoints <= 0) 
		{
			KillEnemy ();

		}
	}

	void ProcessHit()
	{
		GetComponent<AudioSource>().PlayOneShot (enemyDamageSfx);
	
		hitPoints = hitPoints - 1; 
	}
		
	void KillEnemy ()
	{
		var vfx = Instantiate (explode, transform.position, Quaternion.identity);
		vfx.Play ();

		float destroyDelay = vfx.main.duration;

		Destroy (vfx.gameObject, destroyDelay);

		AudioSource.PlayClipAtPoint (enemyDeathSfx, Camera.main.transform.position);
		//Debug.Break ();
		Destroy (gameObject);
	}
}
