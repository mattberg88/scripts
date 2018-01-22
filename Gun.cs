using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bullet;
	public float shootSpeed = 1;
	private float shootVal = 0;
	public Transform shoot;
	private Vector3 antiShoot;
	private Rigidbody rbody;
	private Collider playerCollider;
	private Collider enemyCollider;
	// Use this for initialization
	void Start () {

		rbody = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Rigidbody>();
		playerCollider = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Collider>();
		enemyCollider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider>();

	}
	void FixedUpdate(){
		Physics.IgnoreCollision (playerCollider, this.GetComponent<Collider>());

		if (transform.parent == null) {
			Physics.IgnoreLayerCollision (10, 11, true);
		}else{
			Physics.IgnoreLayerCollision (10, 11, false);
		}

	}
	
	// Update is called once per frame
	void Update () {





		if (transform.parent == GameObject.FindGameObjectWithTag("Hand").transform) {
			if (shootVal == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					FindObjectOfType<AudioManager> ().Play ("GunShoot");
					antiShoot = transform.position - shoot.position;
					rbody.AddForce (antiShoot * 50,ForceMode.Impulse);
					Debug.Log (antiShoot);
					Instantiate (bullet, shoot.transform.position, shoot.transform.rotation);
					shootVal = 1;
					StartCoroutine ("shootWait");

				}
			}
		}
	}
	IEnumerator shootWait()
	{
		yield return new WaitForSeconds (shootSpeed);
		shootVal = 0;

	}



}
