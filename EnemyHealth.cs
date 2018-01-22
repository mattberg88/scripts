using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public GameObject enemy;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 wantedPos = Camera.main.WorldToScreenPoint (enemy.transform.position);
		transform.position = wantedPos +=  Vector3.up * 30;
		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

	

	}
}
