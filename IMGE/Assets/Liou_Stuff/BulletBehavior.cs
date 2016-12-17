using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public bool friendly;
    public float bulletSpeed;
    public float lifeTime;
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed; // bei richtiger Rotation muss forward
        Destroy(gameObject, lifeTime);//nach lifeTime Sekunden despawnt bullet
    }
	
	void Update () {
		
	}
}
