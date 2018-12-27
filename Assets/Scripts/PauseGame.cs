using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour {

	public FirstPersonController ThePlayer;

	private bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			if (!paused) {
				Time.timeScale = 0.0f;
				paused = true;
				ThePlayer.enabled = false;
				Cursor.visible = true;
			} else {
				Time.timeScale = 1.0f;
				paused = false;
				ThePlayer.enabled = true;
				Cursor.visible = false;
			}
		}
	}
}
