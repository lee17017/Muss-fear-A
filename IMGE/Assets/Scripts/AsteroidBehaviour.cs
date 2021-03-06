﻿using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {
	public float speed;
    public int HP;
    public GameObject Explo;
    // Use this for initialization
	void Start () {
	}

    // Update is called once per frame
	void Update () {
        Move();
        if (transform.position.x < -1000 || transform.position.x > 1000 || transform.position.z > 1000 || transform.position.z < -1000)
            Destroy(this.gameObject);
    }
    
    public void Spawn(float x, float y, float speed)
    {

    }
	
    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {

            GameObject temp = Instantiate(Explo);
            temp.transform.position = col.gameObject.transform.position;
            Destroy(col.gameObject);
            HP -= 7;
        }
        else if (col.tag == "Asteroid" && HP <= col.GetComponent<AsteroidBehaviour>().HP)
        {
            Instantiate(Explo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (HP <= 0)
        {
            Instantiate(Explo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }



}
