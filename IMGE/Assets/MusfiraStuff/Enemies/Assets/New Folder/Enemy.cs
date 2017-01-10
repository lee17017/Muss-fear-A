using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
   
    int MinDist = 5;
    int MoveSpeed = 4;
    int MaxDist = 10;
    GameObject player;

	// Use this for initialization
	void Start () {
        //transform.position = Vector3.MoveTowards(transform.position, .transform.position, .03);
    }
	
	// Update is called once per frame
	void Update () {
   	
	}
}
