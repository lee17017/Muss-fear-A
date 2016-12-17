using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour {

    public float rotateSpeed=50f;
    public float deadAngle=30f;
    public GameObject bullet;

    private GameObject bulletSpawnPoint;
	// Use this for initialization
	void Start () {
        bulletSpawnPoint = GameObject.Find("BulletSpawnPoint");
	}
	
	// Update is called once per frame
	void Update () {

        //Rotation der Kanone in einem Bereich
        float tmp = Input.GetAxis("Horizontal");
        float curRot = transform.rotation.eulerAngles.y; // EulerAngles gehn von 0 bis 360 => -0 bis -180 wird auf 360 bis 180 gemappt

        if((tmp >0 && (curRot < 180-deadAngle || curRot >180)) || (tmp < 0 && (curRot > 180 + deadAngle || curRot < 180)))
            transform.Rotate(new Vector3(0,tmp,0) * Time.deltaTime * rotateSpeed);


        //Schießen
        if (Input.GetKey("space")) // muss zu GetKeyDown werden aber so ist grad lustiger
        {
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
        }

    }
}
