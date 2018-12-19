using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup9mm : MonoBehaviour {
	
	public static float DistanceFromTarget;

	public GameObject AmmoDisplay;
	public Text InstructionDisplay;
	public AudioSource Pickup9mmAudio;

	public GameObject FakeGun;
	public GameObject RealGun;
	public GameObject ObjectiveComplete;

	private float ToTarget;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {

		DistanceFromTarget = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver() {
		if (DistanceFromTarget <= 2) {
			InstructionDisplay.text = "Take 9mm";
		}
		if (Input.GetButtonDown ("Action")) {
			if (DistanceFromTarget <= 2) {
				Take9mm ();
				ObjectiveComplete.SetActive (true);
			}
		}
	}

	void OnMouseExit() {
		InstructionDisplay.text = "";
	}

	void Take9mm() {
		Pickup9mmAudio.Play ();
		transform.position = new Vector3 (0.0f, -1000.0f, 0.0f);
		FakeGun.SetActive(false);
		RealGun.SetActive (true);
		AmmoDisplay.SetActive (true);
	}
}
