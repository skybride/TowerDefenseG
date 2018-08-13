using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour {

	[SerializeField] Collider collisionMesh;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnParticleCollision(GameObject other)
	{
		print ("I'm hit! ");
		Destroy (gameObject);

	}
		
}
