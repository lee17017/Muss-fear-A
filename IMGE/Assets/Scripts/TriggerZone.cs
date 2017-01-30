using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {

    public GameObject[] spawnPoints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        Vector3 playerPos = col.transform.position;
        Vector3 thisPos = this.transform.position;

    }

}
