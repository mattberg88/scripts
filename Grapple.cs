using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {
	public float bulletSpeed;
	public LineRenderer grappleLine;
	float grappleVal = 0;
	float grappleShoot = 0;
	Vector3 grapplePos;
	Quaternion grappleRot;
	public Transform hand;
	MeshRenderer rend;
	private GameObject player;
	Rigidbody rbody;
	// Use this for initialization
	void Start () {
		rend = GetComponent<MeshRenderer> ();
		player = GameObject.FindGameObjectWithTag("MainChara");
		rbody = player.GetComponent<Rigidbody> ();
	}



	// Update is called once per frame
	void Update () {
		
		if (grappleShoot == 0) {
			transform.position = hand.transform.position;
			transform.rotation = hand.transform.rotation;
			rend.enabled = false;
			grappleLine.enabled = false;
			if (Input.GetButtonDown ("Fire2")) {
				grappleShoot = 1;
				return;
			}
		}


		
		if (grappleShoot == 1) {
			rend.enabled = true;
			grappleLine.enabled = true;
			if (grappleVal == 0){
					transform.Translate (0, bulletSpeed, 0);
		}

			if (Input.GetButtonDown ("Fire2")) {
				grappleShoot = 0;
				grappleVal = 0;
				return;
			}
		}


			if (grappleVal == 1) {


				rbody.AddForce ((transform.position-hand.position)*5, ForceMode.Acceleration);
					return;
				}

		


	}
			




	void OnTriggerEnter(Collider other){


		if (grappleShoot == 1) {
			if (other.gameObject.CompareTag ("Enemy")) {
				grappleVal = 1;
		
			}
			if (other.gameObject.CompareTag ("Stabable")) {
				grappleVal = 1;			

			}
			if (other.gameObject.CompareTag ("Ground")) {
				grappleVal = 1;
	


			}
		}
	}
}
