using UnityEngine;
using System.Collections;

public class CloneScene : MonoBehaviour {

	public Collider triggerZone;
	public AudioClip soudEffect;
	private bool walking = true;
	private bool cameraFade = false;
	// Use this for initialization
	void Start () {
		animation.wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
		if (walking) {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(6, 0.1f, 0), Time.deltaTime);
		}
		if (cameraFade) {
			Camera.main.rect = new Rect(0, Mathf.Lerp(Camera.main.rect.y,0.5f, Time.deltaTime), 1, Mathf.Lerp(Camera.main.rect.height, 0.5f, Time.deltaTime));
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
		audio.PlayOneShot(soudEffect);
		GetComponent<Dialogue>().enableSpeech = true;
		GetComponent<Dialogue>().Start();
		triggerZone.gameObject.SetActiveRecursively(true);
		cameraFade = true;
		yield return new WaitForSeconds(3);
		animation.wrapMode = WrapMode.Loop;
		animation.Play();
		walking = true;
		triggerZone.gameObject.SetActiveRecursively(false);
		Destroy(GameObject.Find("Sparkle Rising(Clone)"));
	}
}
