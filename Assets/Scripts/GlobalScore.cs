using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour {

	public static int CurrentScore;
	public Text ScoreText;

	private int InternalScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InternalScore = CurrentScore;
		ScoreText.text = "" + InternalScore;
	}
}
