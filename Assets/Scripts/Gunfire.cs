using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour {

	public AudioSource gunsound;
	public Animation gunshot;
	public GameObject Flash;

	private WaitForSeconds FireflashTempo;

	// Use this for initialization
	void Start () {
		gunsound = GetComponent<AudioSource> ();
		gunshot = GetComponent<Animation> ();
		FireflashTempo = new WaitForSeconds (0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalAmmo.LoadedAmmo >= 1) {
			if (Input.GetButtonDown ("Fire1")) {
				gunsound.Play ();
				StartCoroutine ("FireFlash");
				gunshot.Play ("Gunshot");
				GlobalAmmo.LoadedAmmo -= 1;
			}
		}
	}

	IEnumerator FireFlash() {
		Flash.SetActive (true);
		yield return FireflashTempo;
		Flash.SetActive (false);
	}
}
