using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour {

	public static int PlayerHealth = 10;
	public Text HealthDisplay;

	public int InternalHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InternalHealth = PlayerHealth;

		HealthDisplay.text = "Health: " + InternalHealth;

		if (PlayerHealth == 0) {
			SceneManager.LoadScene (2);
		}
	}
}
