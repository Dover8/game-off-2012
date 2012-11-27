using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour {

	public int nextLevel;
	public GameObject Player;
	
	void OnTriggerEnter (Collider other) {
		if(other == Player.collider) {
			Application.LoadLevel(nextLevel);
		}
	}
}
