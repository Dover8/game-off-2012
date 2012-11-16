using UnityEngine;
using System.Collections;

public class ObjectSlide : MonoBehaviour {

	public Transform MarkerOne;
	public Transform MarkerTwo;
	
	private bool inDefaultPosition = true;
	private bool move = false;
	// Use this for initialization
	void Start () {
	
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
