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
	int score;

	// Use this for initialization
	void Start () {
		//EnemySpawner enemyPrefab = FindObjectOfType<Enemy> ();
		//var Enemy = enemyPrefab.GetType();
		StartCoroutine (spawnNewEnemies ());
		numSpawn.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnNewEnemies()
	{
		while(true) 
		{
			AddScore ();
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
