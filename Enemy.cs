﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public GameObject hand;
	private float speedPerSec;
	private Vector3 oldPosition;
	private float damagePunch;
	private Vector3 antiPunch;
	Quaternion hitAngle;
	Vector3 hitDirection;
	Vector3 hitForce;
	private Rigidbody rbody;
	Animator anim;
	public Transform player;
	Vector3 direction;
	float angle;
	public GameObject enemyHand;
	public GameObject gun;
	float attackVal = 0;
	public Transform gunTrans;
	public GameObject bullet;
	public Slider enemyHealth;
	public GameObject deadEnemy;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		Instantiate (enemyHealth, transform.position, transform.rotation);
	}

	// Update is called once per frame
	void FixedUpdate () {
		speedPerSec = Vector3.Distance (oldPosition, hand.transform.position) / Time.deltaTime;
		oldPosition = hand.transform.position;

		Vector3 fwd = transform.TransformDirection(Vector3.right);

		if (Physics.Raycast(transform.position, fwd, 50))
			Debug.DrawRay(transform.position,fwd,Color.green,20);
	}

	void Update ()
	{
		Physics.IgnoreCollision (GetComponent<Collider>(), enemyHand.GetComponent<Collider>());

		direction = player.position - this.transform.position;
		angle = Vector3.Angle (direction, this.transform.forward);

	
		if (Vector3.Distance (player.position, this.transform.position) < 30 )
		{

			direction.y = 0;

			//this.transform.rotation = Quaternion.Slerp (this.transform.rotation,Quaternion.LookRotation (direction), 0.1f);


			if (direction.magnitude > 5) {
				if (direction.x <= 0)

				{
					this.transform.Translate (-0.02f, 0, 0);
				}

				if (direction.x >= 0)

				{
				this.transform.Translate (0.02f, 0, 0);
				//chase
				}



			} else {
				if (attackVal == 0) {
					StartCoroutine ("AttackWait");
					//attack

				}
			}
		} 
		else {
			//idle

		}


		enemyHand.transform.position = player.transform.position;
		Vector3 handOrigin = enemyHand.transform.position - transform.position;


		enemyHand.transform.rotation = Quaternion.LookRotation (Vector3.forward,handOrigin);


		//clamping and normalizing hand distance
		Vector3 clampedPosition = enemyHand.transform.position;
		clampedPosition.x = Mathf.Clamp (handOrigin.x, -1, 1);
		clampedPosition.y = Mathf.Clamp (handOrigin.y, -1, 1);
		clampedPosition.Normalize ();

		//applying clamped and normalized value if beyond a certain distance from center
		if (handOrigin.sqrMagnitude > 1f) {

			enemyHand.transform.position = clampedPosition + transform.position;

		}
		if (enemyHand.transform.localPosition.x >=0) {
			gun.transform.localRotation = Quaternion.identity;

		}

		if (enemyHand.transform.localPosition.x <=0) {
			gun.transform.localRotation = Quaternion.Euler (0, 180, 0);
		}


		if (enemyHealth.value == 0) {
			transform.Rotate (0, 0, -10);
			Instantiate (deadEnemy, transform.position, transform.rotation);
			Destroy (gameObject);

		}



	}








	void OnTriggerEnter(Collider other){
		if (speedPerSec >= 25) {
			damagePunch = speedPerSec - 25;
			if (hand.transform.childCount == 0) {
				if (other.gameObject.CompareTag ("Hand")) {
					FindObjectOfType<AudioManager> ().Play ("Punch");
					antiPunch = transform.position - oldPosition;
					rbody.AddForce ((Vector3.up * 7) + antiPunch * (speedPerSec-10), ForceMode.Impulse);
					enemyHealth.value -= 5;
				}
			}
			if (other.gameObject.CompareTag ("Knife")) {
				FindObjectOfType<AudioManager> ().Play ("Stab");
				antiPunch = transform.position - oldPosition;
				rbody.AddForce (antiPunch * (speedPerSec-10), ForceMode.Impulse);
				enemyHealth.value -= 20;
		}

	}





	}
	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "Bullet") {
			FindObjectOfType<AudioManager> ().Play ("Stab");

			ContactPoint contact = collision.contacts [0];
			enemyHealth.value -= 10;
				rbody.AddForce (contact.point * -5, ForceMode.Impulse);

		}
	}
	IEnumerator AttackWait(){
		attackVal = 1;

		Instantiate (bullet, gunTrans.position, gunTrans.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		yield return new WaitForSeconds (2);
		attackVal = 0;

	}



}

