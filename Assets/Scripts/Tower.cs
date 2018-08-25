﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour {
	//Parameters
	[SerializeField] Transform objectToPan;
	[SerializeField] float attackRange = 10f;
	[SerializeField] ParticleSystem projectileParticle;

	public Waypoint baseWaypoint;

	//State of each tower
	Transform targetEnemy;
	
	// Update is called once per frame
	void Update () {
		SetTargetEnemy ();
		if (targetEnemy) {
			objectToPan.LookAt (targetEnemy);
			fireAtEnemy ();
		}
		else
		{
			Shoot (false);
		}
	}

	private void SetTargetEnemy()
	{
		var sceneEnemies = FindObjectsOfType<EnemyDamage> ();
		if (sceneEnemies.Length == 0) { return; } //guard condition

		Transform closestEnemy = sceneEnemies[0].transform;

		foreach (EnemyDamage testEnemy in sceneEnemies) 
		{
			closestEnemy = GetClosest (closestEnemy, testEnemy.transform);
		}

		targetEnemy = closestEnemy;
	}

	private Transform GetClosest(Transform transformA, Transform transformB)
	{
		var distToA = Vector3.Distance (transform.position, transformA.position);
		var distToB = Vector3.Distance (transform.position, transformB.position);

		if (distToA < distToB) 
		{
			return transformA;
		}
		return transformB;
	}

	/* tired myself
	void checkRange()
	{
		if (targetEnemy) 
		{
			float dist = Vector3.Distance (targetEnemy.position, transform.position);
			print ("Distance to other: " + dist);
	}
	*/


	private void fireAtEnemy ()
	{
		float distanceToEnemy = Vector3.Distance (targetEnemy.transform.position, gameObject.transform.position);
		if (distanceToEnemy <= attackRange) 
		{
			Shoot (true);
		}
		else
		{
			Shoot (false);
		}
	}

	private void Shoot(bool isActive)
	{
		var emissionModule = projectileParticle.emission;
		emissionModule.enabled = isActive;
	}

}
