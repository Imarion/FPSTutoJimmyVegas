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

	public bool IsAttacking = false;
	public GameObject ScreenFlash;
	public AudioSource Hurt01, Hurt02, Hurt03;
	public int PainSound;

	private RaycastHit Shot;
	private WaitForSeconds wfsAtatckAnim, wfsFlash, wfs1sec;

	// Use this for initialization
	void Start () {
		wfsAtatckAnim = new WaitForSeconds (0.9f); // zombie attack animation length
		wfsFlash = new WaitForSeconds(0.05f);
		wfs1sec = new WaitForSeconds(1.0f);
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
			if (!IsAttacking) {
				StartCoroutine ("EnemyDamage");
			}
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

	IEnumerator EnemyDamage() {
		IsAttacking = true;

		PainSound = Random.Range (1, 4);
		yield return wfsAtatckAnim;
		ScreenFlash.SetActive (true);
		GlobalHealth.PlayerHealth -= 1;
		switch (PainSound) {
		case 1:
				Hurt01.Play();
				break;
			case 2:
				Hurt02.Play();
				break;
			case 3:
				Hurt03.Play();
				break;
		}
		yield return wfsFlash;
		ScreenFlash.SetActive (false);
		yield return wfs1sec;

		IsAttacking = false;
	}
}
