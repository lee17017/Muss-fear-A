using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public GameObject arrow;
	private arrowScript arr;
    // Use this for initialization
	void Start () {
        arr = arrow.GetComponent<arrowScript>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
