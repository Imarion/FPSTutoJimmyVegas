using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.UIElements.GraphView;

public class EnemyScriptSpider : MonoBehaviour {

	public int EnemyHealth = 15;
	public SpiderFollow sf;
	public Animation DieAnim;

	private WaitForSeconds wfsDieAnim;

	// Use this for initialization
	void Start () {
		wfsDieAnim = new WaitForSeconds (0.48f);
	}
	
	// Update is called once per frame
	void Update () {
		if (EnemyHealth <= 0) {
			//Destroy(gameObject);
			sf.enabled = false;
			DieAnim.Play ("die");
			StartCoroutine ("EndSpider");
		}
	}

	public void DeductPoints (int DamageAmount) {
		EnemyHealth -= DamageAmount;
	}

	IEnumerator EndSpider() {
		yield return wfsDieAnim;
		Destroy (gameObject);
	}
}
