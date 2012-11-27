using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Dialogue : MonoBehaviour {

	public Texture2D[] images;
	public AudioClip[] voices;
	public string[] subtitles;
	public bool enableSpeech;
	private int comboPointer = 0;
	private int maxDialogue;
	
	// Use this for initialization
	public void Start () {
		maxDialogue = voices.Length;
		if(enableSpeech) { //for starting speech on script start
			StartCoroutine(StartDialogue());
		}
	}
	
	void OnGUI () {
		if(enableSpeech) {
			GUI.Box(new Rect(100,Screen.height-130, Screen.width-100, 80), "");
			GUI.DrawTexture(new Rect(110,Screen.height -120, 60,60), images[comboPointer], ScaleMode.StretchToFill, true, 10.0f);
			GUI.Label(new Rect(180, Screen.height-130, Screen.width - 180, 60), subtitles[comboPointer]);
		}
	}
	
	IEnumerator StartDialogue () {
		audio.PlayOneShot(voices[comboPointer]);
		yield return new WaitForSeconds(5);
		if(comboPointer==maxDialogue-1) {
			enableSpeech = false;
			images = null;
			voices = null;
			comboPointer = 0;
			maxDialogue = 0;
		} else {
			comboPointer++;
			StartCoroutine(StartDialogue());
		}
	}
}
