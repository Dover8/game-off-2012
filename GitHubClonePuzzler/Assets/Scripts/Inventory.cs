using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public GameObject[] inventory;
	
	// Use this for initialization
	public void AddItem (GameObject item) {
		foreach (GameObject g in inventory) {
			if(item.name == g.name)
				g.SetActiveRecursively(true);
		}
	}
	
	// Update is called once per frame
	void RemoveItem (GameObject item) {
	
	}
}
