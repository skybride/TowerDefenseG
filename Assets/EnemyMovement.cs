using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<Waypoint> path;

	void Start ()
	{
		StartCoroutine(FollowPath());
	}

	IEnumerator FollowPath()
	{
		print ("Starting patrol...");
		foreach (Waypoint waypoint in path) 
		{
			transform.position = waypoint.transform.position;
			print ("Visting block: " + waypoint);
			yield return new WaitForSeconds (1f); 
		}
		print ("Ending patrol");
	}
}
