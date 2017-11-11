﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject fallingBlockPrefab;
	public Vector2 secondBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;


	Vector2 screenHalfSizwWorldUnits;

	// Use this for initialization
	void Start () {
		screenHalfSizwWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp (secondBetweenSpawnsMinMax.y, secondBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			nextSpawnTime = Time.time + secondsBetweenSpawns;


			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizwWorldUnits.x, screenHalfSizwWorldUnits.x), screenHalfSizwWorldUnits.y);
			GameObject newBlock = (GameObject)Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
	
		}
		}
}
