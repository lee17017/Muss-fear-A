using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	Quaternion start, erg, ende;
	// Use this for initialization
	void Start () {
		start = Quaternion.Euler(0, 10, 0);
		ende = Quaternion.Euler(0, 191, 0);
		erg = start;
	}
	
	// Update is called once per frame
	void Update () {
		erg = Quaternion.Slerp(erg, ende, Time.time*0.05f);
		Debug.Log("A: " + erg.eulerAngles.y);
	}
}
