using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LeverPullEffect : MonoBehaviour {

	private bool flip = false;
	public float rotSpeed = 60.0f; //degrees per second
	public float rotationAmount = 60.0f;
	private bool activated = false;
	public GameObject objectToTrigger;
	
	void Activate () {
		activated = true;
		objectToTrigger.SendMessage("Activate");
		audio.Play();
	}
	
	void Update () {
		if(activated) {
			if (!flip) {
				transform.Rotate (rotationAmount * Time.deltaTime, 0, 0);
				if(transform.localRotation.eulerAngles.x > rotationAmount) {
					activated = false;
					flip = !flip;
				}
			} else {
				transform.Rotate (-rotationAmount * Time.deltaTime, 0, 0);
				if(transform.localRotation.eulerAngles.x < 2) {
					activated = false;
					flip = !flip;
				}
			}
		}
	}
}
