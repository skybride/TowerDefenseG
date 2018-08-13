using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] ParticleSystem explosion;

	void Start ()
	{
		Pathfinder pathfinder = FindObjectOfType<Pathfinder> ();
		var path = pathfinder.GetPath ();
		StartCoroutine (FollowPath(path));
	}
		
	IEnumerator FollowPath(List<Waypoint> path)
	{
		print ("Starting patrol...");
		foreach (Waypoint waypoint in path) 
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds (1f); 
		}
		print ("Ending patrol");
	}
}
