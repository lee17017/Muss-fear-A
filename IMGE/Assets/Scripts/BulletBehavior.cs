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
        StartCoroutine("destruction");
    }

    IEnumerator destruction()
    {
        yield return new WaitForSeconds(lifeTime);
        GameObject temp = Instantiate(explosion);
        temp.transform.position = this.gameObject.transform.position;
        Destroy(gameObject);
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

 
}
