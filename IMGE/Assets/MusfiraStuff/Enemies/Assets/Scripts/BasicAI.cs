using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {

    public Transform target;
    public Transform myTransform;
   public float speed = 5; 
    void Start()
    {
       
    }
	// Update is called once per frame
	void Update () {
       
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
