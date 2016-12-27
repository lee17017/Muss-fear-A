using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    public bool friendly;
    public float bulletSpeed;
    public float lifeTime;
    public GameObject explosion;
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed; // bei richtiger Rotation muss forward
        Destroy(gameObject, lifeTime);//nach lifeTime Sekunden despawnt bullet
    }
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);

            //simuliere Explosion mit schrei
            GameObject temp = (GameObject) Instantiate(explosion);
            Destroy(temp, 2);
        }
        else if (col.transform.tag == "Wall")
        {
            Destroy(this.gameObject);

            //Explosion
          
        }
    }
}
