using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour {

	float roundStartDelayTime = 3;
	float roundStartTime;
	int waitTime;
	bool roundStarted;

	// Use this for initialization
	void Start () {
		print("Press the spacebar once you think the alotted time is up mah nigga.");
		Invoke ("SetNewRandomTime", roundStartDelayTime);
		SetNewRandomTime ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && roundStarted) {
			roundStarted = false;
			float playerWaitTime = Time.time - roundStartTime;
			float error = Mathf.Abs(waitTime - playerWaitTime);
		
			string message = "";
			if (error < .15f) {
				message = "DAS MAH NIGGA";
			} else if (error < .75f) {
				message = "you aite, bitch";
			}
			else if (error < 1.25f)
				{
				message = "mayne you a regular bitch ass nigga";
				}
			else {
				message = "get yo ass outta here, bad timing-ass non secondarily aware -ass hoe";
			}


			print ("You waited for " + playerWaitTime + " seconds. That's " + error + "seconds off. " + message);
			Invoke ("SetNewRandomTime", roundStartDelayTime);
		}
	}
	void SetNewRandomTime()
	{
		waitTime = Random.Range (5, 21);
		roundStartTime = Time.time;
		roundStarted = true;
		print (waitTime + "seconds.");
}
}