using UnityEngine;
using System.Collections;

public class DeactivateZone : MonoBehaviour {

	public GameObject zone;
	private bool conditionMet = false;
	
	void OnTriggerEnter (Collider other) {
		if(conditionMet)
			zone.active = false;
	}
	
	void OnTriggerExit () {
		if(!conditionMet)
			zone.active = true;
	}
	
	void Moved () {
		conditionMet = true;
	}
}
