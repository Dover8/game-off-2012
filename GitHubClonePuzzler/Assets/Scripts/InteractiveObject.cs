using UnityEngine;
using System.Collections;

public class InteractiveObject : MonoBehaviour {

	public GameObject player;
	public GUIText label;
	private bool playerNear = false;
	private bool used = false;
	
	void OnTriggerEnter (Collider other) {
		if(!used && other == player.collider) {
			label.gameObject.active = true;
			playerNear = true;
		}
	}
	
	void OnTriggerExit (Collider other) {
		if(other == player.collider) {
			playerNear = false;
			used = false;
		}
	}
	
	void Update () {
		if(!playerNear || used)
			return;
		
		if (Input.GetKeyDown(KeyCode.E)) {
			gameObject.BroadcastMessage("Activate");
			label.gameObject.active = false;
			used = true;
		}
	}	
}
