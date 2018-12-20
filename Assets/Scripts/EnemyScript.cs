using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.UIElements.GraphView;

public class EnemyScript : MonoBehaviour {

	public int EnemyHealth = 10;
	public ZombieFollow zf;
	public Animation ZombieDie;

	private WaitForSeconds wfsZombieDieAnim;

	// Use this for initialization
	void Start () {
		wfsZombieDieAnim = new WaitForSeconds (3);
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth <= 0) {
			//Destroy(gameObject);
			zf.enabled = false;
			ZombieDie.Play ("Dying");
			StartCoroutine ("EndZombie");
		}
	}

	public void DeductPoints (int DamageAmount) {
		EnemyHealth -= DamageAmount;
	}

	IEnumerator EndZombie() {
		yield return wfsZombieDieAnim;
		Destroy (gameObject);
	}
}
