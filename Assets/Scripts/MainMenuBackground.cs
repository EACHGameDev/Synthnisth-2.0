using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour {

	public RectTransform background;

	void Awake () {

		background.sizeDelta = new Vector2 (Screen.width, Screen.height);
		
	}
	
	void Update () {
		
	}
}
