using UnityEngine;
using System.Collections;

public class TwoPlayerLevelProgress : MonoBehaviour {

	public int nextLevel;
	public GameObject Player1;
	public GameObject Player2;
	private int inZone = 0;
	
	void OnTriggerEnter (Collider other) {
		if(other == Player1.collider || other == Player2.collider) {
			inZone++;
		}
		
		if(inZone == 2) {
			Application.LoadLevel(nextLevel);		
		}
	}
	
	void OnTriggerExit (Collider other) {
		if(other == Player1.collider || other == Player2.collider) {
			inZone--;
		}
	}		
}
