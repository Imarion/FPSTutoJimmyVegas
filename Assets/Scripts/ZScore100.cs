using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ZScore100 : MonoBehaviour {

	public GameObject ObjectiveComplete;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DeductPoints(int DamaAmount) {
		GlobalScore.CurrentScore += 100;
		ObjectiveComplete.SetActive (true);
	}
}
