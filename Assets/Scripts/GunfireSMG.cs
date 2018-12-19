using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunfireSMG : MonoBehaviour {

	public Animator Gunshot;

	public AudioSource SMGSound;
	public GameObject Flash;

	public GameObject UpCurs, DownCurs, RightCurs, LeftCurs;

	Animator UpCursAnim, DownCursAnim, RightCursAnim, LeftCursAnim;

	private int AmmoCount;
	private Boolean Firing;
	private WaitForSeconds FireflashTempo;

	// Use this for initialization
	void Start () {
		UpCursAnim = UpCurs.GetComponent<Animator> ();
		DownCursAnim = DownCurs.GetComponent<Animator> ();
		RightCursAnim = RightCurs.GetComponent<Animator> ();
		LeftCursAnim = LeftCurs.GetComponent<Animator> ();

		FireflashTempo = new WaitForSeconds (0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		AmmoCount = GlobalAmmo.LoadedAmmo;
		if (Input.GetButton ("Fire1")) {
			if (AmmoCount >= 1) {
				if (!Firing) {
					StartCoroutine ("SMGFire");
				}
			}
		}
	}
				
	IEnumerator SMGFire() {
		Firing = true;

		UpCursAnim.enabled = true;
		DownCursAnim.enabled = true;
		RightCursAnim.enabled = true;
		LeftCursAnim.enabled = true;

		GlobalAmmo.LoadedAmmo--;
		Gunshot.enabled = true;
		SMGSound.Play ();
		Flash.SetActive (true);
		yield return FireflashTempo;
		Flash.SetActive (false);
		Gunshot.enabled = false;

		UpCursAnim.enabled = false;
		DownCursAnim.enabled = false;
		RightCursAnim.enabled = false;
		LeftCursAnim.enabled = false;

		Firing = false;

	}		
}
