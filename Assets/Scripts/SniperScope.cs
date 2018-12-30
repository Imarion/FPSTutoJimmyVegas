using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperScope : MonoBehaviour {

	public Camera FPCCam;
	public GameObject Cursor;
	public GameObject SniperScopeTex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			FPCCam.fieldOfView = 20;
			Cursor.SetActive(false);
			SniperScopeTex.SetActive (true);
		}
		if (Input.GetMouseButtonUp (1)) {
			FPCCam.fieldOfView = 60;
			Cursor.SetActive(true);
			SniperScopeTex.SetActive (false);
		}
	}
}
