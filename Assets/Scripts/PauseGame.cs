using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.IO;

public class PauseGame : MonoBehaviour {

	public FirstPersonController ThePlayer;
	public GameObject PauseMenu;

	private bool paused = false;


	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
			if (!paused) {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Time.timeScale = 0.0f;
				paused = true;
				ThePlayer.enabled = false;
				PauseMenu.SetActive(true);
			} else {
				ResumeGame ();
			}
		}
	}

	public void ResumeGame() {
		Cursor.visible = false;
		Time.timeScale = 1.0f;
		paused = false;
		ThePlayer.enabled = true;
		PauseMenu.SetActive(false);
	}
}
