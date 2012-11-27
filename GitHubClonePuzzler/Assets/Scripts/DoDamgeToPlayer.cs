using UnityEngine;
using System.Collections;

public class DoDamgeToPlayer : MonoBehaviour {

	public GameObject Player;
	public float damagePower;
	
	void OnTriggerEnter (Collider other) {
		if (other == Player.GetComponentInChildren<Collider>())
			Player.SendMessage("Damage", damagePower, SendMessageOptions.DontRequireReceiver);
	}
}
