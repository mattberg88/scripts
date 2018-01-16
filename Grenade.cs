using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	GameObject[] enemies;
	Rigidbody rbody;
	int holdVal = 0;
	public GameObject pin;
	// Use this for initialization
	void Start () {
		
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject go in enemies) {
			rbody = go.GetComponent<Rigidbody> ();
			if (rbody != null){
				Debug.Log ("ass");
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		//if (transform.parent == null) {
		//	Physics.IgnoreLayerCollision (10, 11, true);
		//}else{
		//	Physics.IgnoreLayerCollision (10, 11, false);
		//}
	}



	void Update () {


		if (transform.parent != null) {
			if (holdVal == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					holdVal = 1;
					Instantiate (pin, transform.position, transform.rotation);


				}
			}
		}
		if (holdVal == 1) {
			StartCoroutine ("GrenadeBlow");
		}

	}
	IEnumerator GrenadeBlow(){
		yield return new WaitForSeconds (5);
		FindObjectOfType<AudioManager>().Play("Grenade");

		rbody.AddExplosionForce (300, transform.position, 300);
			Destroy(gameObject);
	}
}
