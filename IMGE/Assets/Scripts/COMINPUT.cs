using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMINPUT : MonoBehaviour {

    public string p1, p2;
	// Use this for initialization
	void Start () {
        if (!p1.Equals("") && !p2.Equals(""))
        {

            InputManager.setStream(p1, p2);
            InputManager.Init();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
