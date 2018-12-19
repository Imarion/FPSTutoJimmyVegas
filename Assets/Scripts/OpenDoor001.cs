using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices.Expando;

public class OpenDoor001 : MonoBehaviour {

	public Text TextDisplay;
	public Animation TheDoorAnim;

	public GameObject ObjectiveComplete;

	private float TheDistance;
	private WaitForSeconds Wf1s, Wf5s;

	// Use this for initialization
	void Start () {
		Wf1s = new WaitForSeconds (1);
		Wf5s = new WaitForSeconds (5);
	}
	
	// Update is called once per frame
	void Update () {
		TheDistance = PlayerCasting.DistanceFromTarget;
	}

	void OnMouseOver() {
		if (TheDistance <= 2) {
			TextDisplay.text = "Open door";
		}
		if (Input.GetButtonDown("Action")) {
			if (TheDistance <= 2) {
				ObjectiveComplete.SetActive (true);
				StartCoroutine ("OpenTheDoor");
			}
		}
	}

	void OnMouseExit() {
		TextDisplay.text = "";
	}

	IEnumerator OpenTheDoor() {		
		TheDoorAnim.enabled = true;
		yield return Wf1s;
		TheDoorAnim.enabled = false;
		yield return Wf5s;
		TheDoorAnim.enabled = true;
		yield return Wf1s;
		TheDoorAnim.enabled = false;
	}
}
