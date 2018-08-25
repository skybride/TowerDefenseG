﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower TowerPrefab;

	Queue<Tower> towerQueue = new Queue<Tower> ();

	public void AddTower(Waypoint baseWaypoint)
	{ 
		print (towerQueue.Count);
		int numTowers = towerQueue.Count;
		if (numTowers < towerLimit) {
			InstantiateNewTower (baseWaypoint);

		} else {
			MoveExistingTower (baseWaypoint);
		}
	}
		

	private void InstantiateNewTower (Waypoint baseWaypoint)
	{
		var newTower = Instantiate (TowerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		baseWaypoint.isPlaceable = false;

		newTower.baseWaypoint = baseWaypoint;
		baseWaypoint.isPlaceable = false;

		towerQueue.Enqueue (newTower);
	}

	private void MoveExistingTower (Waypoint newBaseWaypoint)
	{
		var oldTower = towerQueue.Dequeue ();

		oldTower.baseWaypoint.isPlaceable = true;
		newBaseWaypoint.isPlaceable = false;

		oldTower.baseWaypoint = newBaseWaypoint;

		oldTower.transform.position = newBaseWaypoint.transform.position;

		towerQueue.Enqueue (oldTower);
	}
}
