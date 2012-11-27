using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	void OnGUI () {
		if(GUI.Button(new Rect(Screen.width/2-50, (Screen.height*0.75f), 100, 40), "Start")) {
			Application.LoadLevel(1);
		}
	}
}
