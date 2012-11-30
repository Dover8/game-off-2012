using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {

	public float maxHealth;
	public float health;
	public float fuel;
	public float maxFuel;
	public bool _isPlayerOne;
	
	private float jumpAmount;
	
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
	
	void DidJump () {
		jumpAmount = Time.time;
	}
	
	void DidJumpReachApex () {
		jumpAmount = Time.time - jumpAmount;
		Debug.Log(jumpAmount);
		fuel -= jumpAmount;
		if (fuel < 0) {
			fuel = 0;
			gameObject.BroadcastMessage("SetJumping", false);
		}
		if(_isPlayerOne) {
			Messenger<float, float>.Broadcast("player one fuel update", fuel, maxFuel);
		}
	}
	
	void AddFuel (float amount) {
		fuel += amount;
		if (fuel > maxFuel)
			fuel = maxFuel;
		if(_isPlayerOne) {
			Messenger<float, float>.Broadcast("player one fuel update", fuel, maxFuel);
		}
	}
	
	void AddHealth (float amount) {
		health += amount;
		if(health > maxHealth)
			health = maxHealth;
		if(_isPlayerOne) {
			Messenger<float, float>.Broadcast("player one health update", health, maxHealth);
		} else {
			Messenger<float, float>.Broadcast("player two health update", health, maxHealth);
		}
	}
}
