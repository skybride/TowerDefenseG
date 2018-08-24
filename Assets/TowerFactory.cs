using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower TowerPrefab;

	public void AddTower(Waypoint baseWaypoint)
	{ 
		var towers = FindObjectsOfType<Tower> ();
		int numTowers = towers.Length;
		if (numTowers < towerLimit) {
			InstantiateNewTower (baseWaypoint);

		} else {
			MoveExistingTower ();
		}
	}

	static void MoveExistingTower ()
	{
		print ("Max Towers");
	}

	void InstantiateNewTower (Waypoint baseWaypoint)
	{
		Instantiate (TowerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		baseWaypoint.isPlaceable = false;
	}
}
