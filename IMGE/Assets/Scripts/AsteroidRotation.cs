using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour {
    private float randX;
    private float randY;
    private float randZ;
	// Use this for initialization
	void Start () {
        randX = Random.Range(-10, 10) / 10f;
        randY = Random.Range(-10, 10) / 10f;
        randZ = Random.Range(-10, 10) / 10f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(randX, randY, randZ));
	}
}
