using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour {

	public static float DistanceFromTarget;

	private float ToTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			ToTarget = hit.distance;
			DistanceFromTarget = ToTarget;
		}
	}
}
