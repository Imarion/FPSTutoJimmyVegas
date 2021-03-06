using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunReload : MonoBehaviour {

	public AudioSource ReloadSound;
	public GameObject CrossObject;
	public GameObject MechanicsObject;

	private int ClipCount, ReserveCount, ReloadAvailable;
	private Gunfire ThisGunfire;
	private Animation HandgunReloadAnim;
	private WaitForSeconds Wf1d1s;

	// Use this for initialization
	void Start () {
		ThisGunfire = GetComponent<Gunfire> ();
		HandgunReloadAnim = GetComponent<Animation> ();
		Wf1d1s = new WaitForSeconds (1.1f);
	}
	
	// Update is called once per frame
	void Update () {
		ClipCount = GlobalAmmo.LoadedAmmo;
		ReserveCount = GlobalAmmo.CurrentAmmo;

		if (ReserveCount == 0) {
			ReloadAvailable = 0;
		} else {
			ReloadAvailable = 10 - ClipCount;
		}

		if (Input.GetButtonDown("Reload")) {
			if (ReloadAvailable >= 1) {
				if (ReserveCount <= ReloadAvailable) {
					GlobalAmmo.LoadedAmmo += ReserveCount;
					GlobalAmmo.CurrentAmmo -= ReserveCount;
				} else {
					GlobalAmmo.LoadedAmmo += ReloadAvailable;
					GlobalAmmo.CurrentAmmo -= ReloadAvailable;
				}
				ActionReload();
			}
			StartCoroutine ("EnableScripts");
		}
	}

	private IEnumerator EnableScripts() {
		yield return Wf1d1s;
		ThisGunfire.enabled = true;
		CrossObject.SetActive (true);
		MechanicsObject.SetActive (true);
	}

	void ActionReload() {
		ThisGunfire.enabled = false;
		CrossObject.SetActive (false);
		MechanicsObject.SetActive (false);
		ReloadSound.Play ();
		HandgunReloadAnim.Play ("HandGunReload");
	}
}
