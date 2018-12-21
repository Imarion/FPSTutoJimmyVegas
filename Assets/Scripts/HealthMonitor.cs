using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Macros;

public class HealthMonitor : MonoBehaviour {

	public GameObject Health04, Health03, Health02, Health01, Health00;

	private int CurrentHealth;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		CurrentHealth = GlobalHealth.PlayerHealth;
		switch (CurrentHealth) {
		case 8:
			if (Health04.transform.localScale.y <= 0.0f) {				
				Health04.SetActive (false);
			} else {
				Health04.transform.localScale -= new Vector3 (0.0f, 0.05f, 0.0f);
			}
			break;

		case 6:
			if (Health03.transform.localScale.y <= 0.0f) {				
				Health03.SetActive (false);
			} else {
				Health03.transform.localScale -= new Vector3 (0.0f, 0.05f, 0.0f);
			}
			break;

		case 4:
			if (Health02.transform.localScale.y <= 0.0f) {				
				Health02.SetActive (false);
			} else {
				Health02.transform.localScale -= new Vector3 (0.0f, 0.05f, 0.0f);
			}
			break;

		case 2:
			if (Health01.transform.localScale.y <= 0.0f) {				
				Health01.SetActive (false);
			} else {
				Health01.transform.localScale -= new Vector3 (0.0f, 0.05f, 0.0f);
			}
			break;

		case 0:
			if (Health00.transform.localScale.y <= 0.0f) {				
				Health00.SetActive (false);
			} else {
				Health00.transform.localScale -= new Vector3 (0.0f, 0.05f, 0.0f);
			}
			break;
		}
	}
}
