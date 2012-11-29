using UnityEngine;
using System.Collections;

public class IntroAnimation : MonoBehaviour {

	public GameObject Lerpz;
	public GameObject Ufo;
	
	private bool abduct = false;
	private bool flyAway = false;
	// Use this for initialization
	void Start () {
		Lerpz.animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		if(!abduct) {
			Lerpz.transform.position = Vector3.MoveTowards(Lerpz.transform.position, new Vector3(7,Lerpz.transform.position.y,Lerpz.transform.position.z), Time.deltaTime);
			Ufo.transform.position = Vector3.Slerp(Ufo.transform.position, Lerpz.transform.position + new Vector3(0, 10, 0), Time.deltaTime * 0.5f);
			if(Vector3.Distance(Lerpz.transform.position, Ufo.transform.position) < 15.0f) {
				Abduct();
			}
		} else if (!flyAway){
			Lerpz.transform.position = Vector3.MoveTowards(Lerpz.transform.position, Ufo.transform.position + new Vector3(0,-1, 0), Time.deltaTime * 5);
		}
		else if(flyAway) {
			Ufo.transform.position = Vector3.Slerp(Ufo.transform.position, new Vector3(500, -500, -500), Time.deltaTime);
		}
	}
	
	void Abduct() {
		if (!abduct) {
			abduct = true;
			Lerpz.animation.wrapMode = WrapMode.Once;
			Lerpz.animation.PlayQueued("jump", QueueMode.PlayNow, PlayMode.StopAll);
			Lerpz.GetComponent<Dialogue>().enableSpeech = true;
			Lerpz.GetComponent<Dialogue>().Start();
			Ufo.GetComponentInChildren<Light>().enabled = true;
			StartCoroutine(WaitForBeam());
		}
	}
	
	IEnumerator WaitForBeam () {
		yield return new WaitForSeconds(2.5f);
		Destroy(Lerpz);
		flyAway = true;
		yield return new WaitForSeconds(3);
		Application.LoadLevel(2);
	}		
}
