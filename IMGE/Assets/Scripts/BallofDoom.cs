using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallofDoom : MonoBehaviour {
    private GameObject player;
    public float speed;
    public float HP;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Playership");
	}
	
	// Update is called once per frame
	void Update () {
        HP -= Time.deltaTime*2;
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (HP < 0)
        {
            GameObject temp = Instantiate(explosion);
            temp.transform.position = transform.position;
            Destroy(this.gameObject);
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            HP -= 7;
            Destroy(col.gameObject);
            GameObject temp = Instantiate(explosion);
            temp.transform.position = col.gameObject.transform.position;
        }

    }


}
