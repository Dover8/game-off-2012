using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public GameObject[] inventory;
	public GameObject fuelBar;
	
	// Use this for initialization
	public void AddItem (GameObject item) {
		foreach (GameObject g in inventory) {
			if(item.name == g.name)
				g.SetActiveRecursively(true);
		}
		if (item.name == "Fuel") {
			gameObject.BroadcastMessage("SetJumping", true);
			SendMessage("AddFuel", 10, SendMessageOptions.DontRequireReceiver);
			GetComponent<Dialogue>().enableSpeech = true;
			GetComponent<Dialogue>().Start();
			fuelBar.SetActiveRecursively(true);
		}
	}
	
	// Update is called once per frame
	void RemoveItem (GameObject item) {
	
	}
}
