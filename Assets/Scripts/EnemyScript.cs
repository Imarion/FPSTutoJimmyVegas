using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.UIElements.GraphView;

public class EnemyScript : MonoBehaviour {

	public int EnemyHealth = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth <= 0) {
			Destroy(gameObject);
		}
	}

	public void DeductPoints (int DamageAmount) {
		EnemyHealth -= DamageAmount;
	}
}
