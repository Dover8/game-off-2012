using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundBank : MonoBehaviour {

	public AudioClip [] soundBank;
	
	// Update is called once per frame
	void Update () {
		PlayRandomSound();
	}
	
	void PlayRandomSound() {
		if(audio.isPlaying) return;
		audio.clip = soundBank[Random.Range(0,soundBank.Length)];
		audio.Play();
	}
	
}
