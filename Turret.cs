using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;
    public float rythm;
    private float timer;
    private GameObject bulletSpawnPoint;
    private float xOffset, zOffset;
    // Use this for initialization

    void Start () {
        bulletSpawnPoint = GameObject.Find(this.name + "/BulletSpawnPoint");
    }
	
	// Update is called once per frame
	void Update () {
        //Anpassen
        timer -= Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(xOffset + player.transform.position.x, 0, zOffset + player.transform.position.z) - transform.position), Time.deltaTime*3);


        if (timer <= 0)
        {
            if(Vector3.Distance(this.transform.position, player.transform.position) < 50f)
                StartCoroutine(Fire1(7));
            timer = rythm;
        }
        
    }

    IEnumerator Fire1(int anz)
    {
        float yRot = player.transform.rotation.eulerAngles.y;
        xOffset = Mathf.Sin(yRot - 180) * 10;
        zOffset = Mathf.Cos(yRot - 180) * 10;
        
        for (int i = 0; i < anz; i++)
        {
            float curRot = transform.rotation.eulerAngles.y; // absolute rotation für instantiation
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
