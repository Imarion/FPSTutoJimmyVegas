using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour {

	public int DamageAmount = 5;
	public float AllowedRange = 15.0f;

	private float TargetDistance;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalAmmo.LoadedAmmo >= 1) {
			if (Input.GetButtonDown ("Fire1")) {

				RaycastHit Shot;
				if (Physics.Raycast (transform.position, transform.forward, out Shot)) {
					TargetDistance = Shot.distance;
					if (TargetDistance < AllowedRange) {
						Shot.transform.SendMessage ("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}
}
