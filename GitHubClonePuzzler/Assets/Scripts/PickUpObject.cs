using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PickUpObject : MonoBehaviour {

	public GameObject player;
	public GameObject toPickUp;
	public GUIText label;
	private bool playerNear = false;
	
	void OnTriggerEnter () {
		if(toPickUp.gameObject.active) {
			label.gameObject.active = true;
			playerNear = true;
		}
	}
	
	void OnTriggerExit () {
		playerNear = false;
	}
	
	void Update () {
		if(!playerNear || !toPickUp.gameObject.active)
			return;
		
		if (Input.GetKeyDown(KeyCode.E)) {
			Inventory script = player.GetComponent("Inventory") as Inventory;
			script.AddItem(toPickUp);
			audio.Play();
			toPickUp.SetActiveRecursively(false);
			label.gameObject.active = false;
			playerNear = false;
		}
	}	
	
	void OnGUI () {
		if(!playerNear)
			return;
	}
}
