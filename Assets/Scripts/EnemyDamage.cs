using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider collisionMesh;
	[SerializeField] int hitPoints = 10;

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
		hitPoints = hitPoints - 1; 
	}
		
	void KillEnemy ()
	{
		Destroy (gameObject);
	}
}
