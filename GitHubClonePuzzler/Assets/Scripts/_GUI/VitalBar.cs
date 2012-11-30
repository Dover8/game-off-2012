using UnityEngine;
using System.Collections;

public class VitalBar : MonoBehaviour {

	public bool _isPlayerOne; //bool to set if this is player 1(true) or 2(false)
	public bool _isFuel; //bool to set if this is a fuel bar
	private float _maxBarLength; //how long the bar can be at max length, will change with player upgrade
	private float _currBarLength; //how long the bar is now
	private GUITexture _vitalBar;
	
	
	// Use this for initialization
	void Start () {		
		_vitalBar = gameObject.GetComponent<GUITexture>();
		_maxBarLength = _vitalBar.pixelInset.width; //set the bar length to the texture width
		
		OnEnable();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnEnable () {
		if(_isPlayerOne) {
			if (_isFuel) {
				Messenger<float, float>.AddListener("player one fuel update", OnChangeVitalBarSize);
			} else {
				Messenger<float, float>.AddListener("player one health update", OnChangeVitalBarSize);
			}
		} else {
			Messenger<float, float>.AddListener("player two health update", OnChangeVitalBarSize);
		}
	}
	
	void OnDisable () {
		if (_isPlayerOne) {
			if (_isFuel) {
				Messenger<float, float>.RemoveListener("player one fuel update", OnChangeVitalBarSize);
			} else {
				Messenger<float, float>.RemoveListener("player one health update", OnChangeVitalBarSize);
			}
		} else {
			Messenger<float, float>.RemoveListener("player two health update", OnChangeVitalBarSize);
		}
	}
	
	public void OnChangeVitalBarSize(float currSize, float maxSize) { //change the vitalbar size in relation to the % value
		if(_vitalBar == null) return;
		_currBarLength = (currSize / maxSize) * _maxBarLength; //this works out the % of the bar
		_vitalBar.pixelInset = new Rect(_vitalBar.pixelInset.x, _vitalBar.pixelInset.y, _currBarLength, _vitalBar.pixelInset.height);
	}		
	
	//set the Player value
	public void SetPlayer(bool b) {
		_isPlayerOne = b;
	}
}
