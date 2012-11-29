using UnityEngine;
using System.Collections;

//this script detects when the players are at 2 different doors
public class TwoDoorLevelProgress : MonoBehaviour {

	public int nextLevel;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject OtherDoor;
	
	private bool firstReady = false;
	private bool secondReady = false;
	
	void OnTriggerEnter (Collider other) {
		if(other == Player1.collider) {
			firstReady = true;
		}
	}
	
	void OnTriggerExit (Collider other) {
		if(other == Player1.collider) {
			firstReady = false;
		}
	}
	
	void Update () {
		if (OtherDoor.GetComponent<Collider>().bounds.Contains(Player2.transform.position)) {
			secondReady = true;
		} else {
			secondReady = false;
		}
		
		if(firstReady && secondReady) {
			Application.LoadLevel(nextLevel);		
		}
	}
}
