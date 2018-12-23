using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour {

	public int DamageAmount = 5;
	public float AllowedRange = 15.0f;

	public GameObject TheBullet;
	public GameObject TheBlood;
	public GameObject TheGreenBlood;

	private float TargetDistance;
	private RaycastHit hit;


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
						//Instantiate(TheBullet, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
						/*
						if (Physics.Raycast(transform.position, transform.forward, out hit)) {
							Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
						}
						*/
						if (Shot.transform.tag == "Zombie") {
							Instantiate (TheBlood, Shot.point, Quaternion.FromToRotation (Vector3.up, Shot.normal));
						} else if (Shot.transform.tag == "Spider") {
								Instantiate (TheGreenBlood, Shot.point, Quaternion.FromToRotation (Vector3.up, Shot.normal));
						} else {
							Instantiate(TheBullet, Shot.point, Quaternion.FromToRotation(Vector3.up, Shot.normal));
						}
					}
				}
			}
		}
	}
}
