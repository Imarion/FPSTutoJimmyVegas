using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperScope : MonoBehaviour {

	public Camera FPCCam;
	public GameObject Cursor;
	public GameObject SniperScopeTex;
	public int fieldView = 60;

	private bool zoomingIn = false;
	private WaitForSeconds wfsZoomTempo;

	// Use this for initialization
	void Start () {
		wfsZoomTempo = new WaitForSeconds (0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			if (!zoomingIn) {
				Cursor.SetActive (false);
				SniperScopeTex.SetActive (true);
				StartCoroutine ("ZoomingCam");
				zoomingIn = true;
			}
		}
		if (Input.GetMouseButtonUp (1)) {
			StopAllCoroutines ();
			fieldView = 60;
			FPCCam.fieldOfView = fieldView;
			Cursor.SetActive(true);
			SniperScopeTex.SetActive (false);
			zoomingIn = false;
		}
	}

	IEnumerator ZoomingCam() {
		while (fieldView > 25) {
			FPCCam.fieldOfView = fieldView;
			fieldView -= 2;
			yield return wfsZoomTempo;
		}
	}
}
