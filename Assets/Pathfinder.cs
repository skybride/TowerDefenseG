﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint>queue = new Queue<Waypoint>();
	[SerializeField] bool isRunning = true; // todo make private

	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Use this for initialization
	void Start () {
		LoadBlocks ();
		ColorStartAndEnd ();
		Pathfind ();
		//ExploreNeighbours ();
	}

	private void Pathfind ()
	{
		queue.Enqueue (startWaypoint);

		while (queue.Count > 0) 
		{
			var searchCenter = queue.Dequeue ();
			print ("Searching from: " + searchCenter);
			HaltIfEndFound (searchCenter);
		}
		print ("Finished pathfinding?");
	}

	private void HaltIfEndFound(Waypoint searchCenter)
	{
		if (searchCenter == endWaypoint) 
		{
			print ("Searching from end node, therefore stopping");
			isRunning = false;
		}
	}

	private void ExploreNeighbours ()
	{
		foreach (Vector2Int direction in directions) 
		{
			Vector2Int exploreCoordinates = startWaypoint.GetGridPos () + direction;
			try
			{
				grid [exploreCoordinates].SetTopColor (Color.blue);
			}
			catch
			{
			}
		}
	}

	private void ColorStartAndEnd ()
	{
		startWaypoint.SetTopColor (Color.green);
		endWaypoint.SetTopColor (Color.red);
	}

	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints) 
		{
			var gridPos = waypoint.GetGridPos ();
			if (grid.ContainsKey(gridPos)) {
				Debug.LogWarning ("Skipping overlapping block " + waypoint);
			} 
			else 
			{
				grid.Add(gridPos, waypoint);
			}
		}
	}
}
