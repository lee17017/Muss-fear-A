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
       
        if (col.transform.tag == "Wall")
        {
            Destroy(this.gameObject);

            //Explosion
          
        }
    }

    void OnDestroy()
    {
        GameObject temp = Instantiate(explosion);
        temp.transform.position = this.gameObject.transform.position;
    }
}
