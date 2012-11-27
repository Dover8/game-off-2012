using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ObjectSlide : MonoBehaviour {

	public Transform MarkerOne;
	public Transform MarkerTwo;
	
	private bool inDefaultPosition = true;
	private bool move = false;

	void Activate () {
		move = true;
		audio.Play();
	}
	
	void OnMouseDown() {
		move = true;
	}
	// Update is called once per frame
	void Update () {
		if(move) {
			if (inDefaultPosition) {
				transform.position = Vector3.Lerp(transform.position, MarkerTwo.position, Time.deltaTime*5.0F);
				if(transform.position == MarkerTwo.position) {
					inDefaultPosition = false;
					move = false;
				}
				SendMessage("Moved", SendMessageOptions.DontRequireReceiver);
			}
			else {
				transform.position = Vector3.Lerp(transform.position, MarkerOne.position, Time.deltaTime*5.0F);
				if(transform.position == MarkerOne.position) {
					inDefaultPosition = true;
					move = false;
				}
			}
				
		}	
	}
}
