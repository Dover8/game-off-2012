using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {

	public float maxHealth;
	public float health;
	public float fuel;
	public bool _isPlayerOne;
	
	void Damage (float amount) {
		health -= amount;
		if(_isPlayerOne) {
			Messenger<float, float>.Broadcast("player one health update", health, maxHealth);
		} else {
			Messenger<float, float>.Broadcast("player two health update", health, maxHealth);
		}
		if(health < 0.1)
			SendMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
	}
	
	void Respawn () {
		health = maxHealth;
		if(_isPlayerOne) {
			Messenger<float, float>.Broadcast("player one health update", health, maxHealth);
		} else {
			Messenger<float, float>.Broadcast("player two health update", health, maxHealth);
		}
	}
}
