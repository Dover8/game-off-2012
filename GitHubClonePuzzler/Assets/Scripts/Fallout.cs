using UnityEngine;
using System.Collections;

public class Fallout : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		other.gameObject.SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
	}
		
}
