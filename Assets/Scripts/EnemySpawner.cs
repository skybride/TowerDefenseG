using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 1f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] Transform enemyParentTransform;
	[SerializeField] Text numSpawn;
	[SerializeField] AudioClip spawnedEnemySfx;

	int score;

	// Use this for initialization
	void Start () {
		//EnemySpawner enemyPrefab = FindObjectOfType<Enemy> ();
		//var Enemy = enemyPrefab.GetType();
		StartCoroutine (spawnNewEnemies ());
		numSpawn.text = score.ToString ();
	}

	IEnumerator spawnNewEnemies()
	{
		while(true) 
		{
			AddScore ();
			GetComponent<AudioSource> ().PlayOneShot (spawnedEnemySfx);
			var newEnemy = Instantiate (enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParentTransform;
			yield return new WaitForSeconds (secondsBetweenSpawns);
		}
	}

	void AddScore ()
	{
		score++;
		numSpawn.text = score.ToString ();
	}
}
