using UnityEngine;
using System.Collections;

public class RandomFlying : MonoBehaviour {
	
	public float minSec;
	public float maxSec;
	
	private float nextChange = 0.0f;
	private Vector3 nextPoint;
		
	// Update is called once per frame
	void Update () {
		if(Time.time > nextChange) {
			nextPoint = Random.insideUnitSphere * 100;
			nextChange = Time.time + Random.Range(minSec, maxSec);
		}
		transform.position = Vector3.Slerp(transform.position, nextPoint, Time.deltaTime);
		
	}
}
