﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {

    public GameObject player;
    public GameObject[] cps;
    private PlayerBehaviour playerScript;
    private float x, z;
    private int max, act;
	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<PlayerBehaviour>();
        max = cps.Length;
         x = cps[0].transform.position.x;
         z = cps[0].transform.position.z;
        act = 0;
        for (int i = 1; i < max; i++)
        {
            cps[i].GetComponent<Renderer>().enabled = false;
            cps[i].GetComponent<Collider>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerScript.checkPointNr != act && act < max-1)
        {
            act = playerScript.checkPointNr;
            cps[act].GetComponent<Renderer>().enabled = true;
            cps[act].GetComponent<Collider>().enabled = true;
            x = cps[act].transform.position.x;
            z = cps[act].transform.position.z;
        }
        
        float dX = x - player.transform.position.x;
        float dZ = z - player.transform.position.z;

        float temp = Mathf.Atan(dZ / dX) / Mathf.PI * 180;
        if (dX > 0)
        {
            temp = temp - 90;
        }
        else
            temp += 90;
        this.transform.rotation = Quaternion.Euler(0,0, temp);
    }
}