using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour {

	private WaitForSeconds wfsplashend;

	// Use this for initialization
	void Start () {
		wfsplashend = new WaitForSeconds (3);
		StartCoroutine ("WaitForSplashEnd");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator WaitForSplashEnd() {
		yield return wfsplashend;
		SceneManager.LoadScene (4);
	}
}
