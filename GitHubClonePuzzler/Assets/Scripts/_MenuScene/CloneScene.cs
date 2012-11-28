using UnityEngine;
using System.Collections;

public class CloneScene : MonoBehaviour {

	public Collider triggerZone;
	private bool walking = true;
	// Use this for initialization
	void Start () {
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		if (walking) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(6, 0.1f, 0), Time.deltaTime);
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other == triggerZone) {
			StartCoroutine(Zapp());
		}
	}

	IEnumerator Zapp () {
		walking = false;
		animation.wrapMode = WrapMode.Once;
		animation.PlayQueued("jump", QueueMode.PlayNow, PlayMode.StopAll);
		GetComponent<Dialogue>().enableSpeech = true;
		GetComponent<Dialogue>().Start();
		triggerZone.gameObject.SetActiveRecursively(true);
		yield return new WaitForSeconds(3);
		animation.wrapMode = WrapMode.Loop;
		animation.Play();
		walking = true;
		triggerZone.gameObject.SetActiveRecursively(false);
		Destroy(GameObject.Find("Sparkle Rising(Clone)"));
	}
}
