using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 1f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
		//EnemySpawner enemyPrefab = FindObjectOfType<Enemy> ();
		//var Enemy = enemyPrefab.GetType();
		StartCoroutine (spawnNewEnemies ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnNewEnemies()
	{
		while(true) 
		{
			Instantiate (enemyPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (secondsBetweenSpawns);
		}
	}

}
