using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	public Transform sphereTransform;

	// Use this for initialization
	void Start () {
		sphereTransform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
