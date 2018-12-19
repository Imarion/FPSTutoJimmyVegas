using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour {

	public static int CurrentAmmo;
	public Text AmmoDisplay;

	private int InternalAmmo;

	public static int LoadedAmmo;
	public Text LoadedAmmoDisplay;

	private int InternalLoadedAmmo;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InternalAmmo = CurrentAmmo;
		InternalLoadedAmmo = LoadedAmmo;

		AmmoDisplay.text = "" + InternalAmmo;
		LoadedAmmoDisplay.text = "" + InternalLoadedAmmo;
	}
}
