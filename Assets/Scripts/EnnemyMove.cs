using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMove : MonoBehaviour {

	public GameObject ThePlayer;
	public GameObject TheEnemy;
	public float EnemySpeed = 1.0f;

	public bool MoveTrigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (MoveTrigger) {
			transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, EnemySpeed);
		}
	}
}
