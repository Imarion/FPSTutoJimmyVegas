using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour {

	public GameObject ThePlayer;
	public float TargetDistance;
	public float AllowedRange = 10.0f;

	public Animation TheEnemyAnim;
	public float EnemySpeed;
	public bool AttackTrigger;

	private RaycastHit Shot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (ThePlayer.transform);
		if (Physics.Raycast (transform.position, transform.forward, out Shot)) {
			TargetDistance = Shot.distance;
			if (TargetDistance < AllowedRange) {
				EnemySpeed = 0.02f;
				if (!AttackTrigger) {
					TheEnemyAnim.Play ("Walking");
					transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
				}
			} else {
				EnemySpeed = 0.0f;
				TheEnemyAnim.Play ("Idle");
			}
		}

		if (AttackTrigger) {
			EnemySpeed = 0.0f;
			TheEnemyAnim.Play ("Attacking");
		}
	}

	void OnTriggerEnter() {
		AttackTrigger = true;
	}

	void OnTriggerExit() {
		AttackTrigger = false;
	}

}
