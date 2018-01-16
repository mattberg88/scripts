using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	private GameObject[] enemy;
	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectsWithTag ("Enemy");
		Debug.Log (enemy.Length);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject dude in enemy){


		Vector3 wantedPos = Camera.main.WorldToScreenPoint (dude.transform.position);
		transform.position = wantedPos +=  Vector3.up * 30;
		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			if (dude == null) {
				transform.localScale = new Vector3 (0, 0, 0);	
				Debug.Log ("dead");
				return;
			}
		}

	

	}
}
