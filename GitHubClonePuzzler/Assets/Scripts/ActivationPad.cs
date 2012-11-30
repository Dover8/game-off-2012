using UnityEngine;
using System.Collections;

public class ActivationPad : MonoBehaviour {

	public GameObject target; 			//the gameobject that will move as a result of this trigger
	private Vector3 targetStartPos;		//the position it starts at
	public GameObject targetEndPos; 	//the position it will move to (empty GameObject)
	
	private bool triggered = false;
	private Vector3 startPos;				//the position of the trigger
	
	void Start() {
		startPos = transform.position;
		targetStartPos = target.transform.position;
	}

	void OnTriggerEnter (Collider other) {
		triggered = true;
	}
	
	void OnTriggerExit (Collider other) {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			//depress the button
			transform.position = Vector3.Lerp(transform.position, startPos + new Vector3(0,-0.09f, 0), Time.deltaTime);
			//move the target to it's position
			target.transform.position = Vector3.Lerp(target.transform.position, targetEndPos.transform.position, Time.deltaTime);
		} else {
			//return to starting Positions
			transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
			target.transform.position = Vector3.Lerp(target.transform.position, targetStartPos, Time.deltaTime * 0.25f);
		}
	}
}
