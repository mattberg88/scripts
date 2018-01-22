using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float bulletSpeed;
	public GameObject blood;
	public GameObject flash;
	// Use this for initialization
	void Start () {
		Instantiate (flash, transform.position, transform.rotation);
		blood= (GameObject)Resources.Load ("BloodSpurt"); 
		StartCoroutine ("BulletLife");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(0,bulletSpeed * Time.deltaTime, 0);
	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Enemy")) {
			Instantiate (blood, transform.position, transform.rotation);
			Destroy (gameObject);

}
		if (other.gameObject.CompareTag ("MainChara")) {
			Instantiate (blood, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		if (other.gameObject.CompareTag ("Stabable")) {
			Destroy (gameObject);

		}
		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);

		}
	}
	IEnumerator BulletLife(){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}

}