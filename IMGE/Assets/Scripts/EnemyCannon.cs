using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour {

    public GameObject player;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    private float rythm;
    private float timer;
    private float xOffset, zOffset;
    // Use this for initialization
    void Start () {
        rythm = Random.Range(2.4f, 3.4f);
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(xOffset + player.transform.position.x, 0, zOffset + player.transform.position.z) - transform.position), Time.deltaTime * 3);


        if (timer <= 0)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < 100f)
                StartCoroutine(Fire1(7));
            timer = rythm;
        }
    }
    IEnumerator Fire1(int anz)
    {
        float yRot = player.transform.rotation.eulerAngles.y;
        xOffset = -Mathf.Sin(yRot - 180) * 10;
        zOffset =- Mathf.Cos(yRot - 180) * 10;

        for (int i = 0; i < anz; i++)
        {
            float curRot = transform.rotation.eulerAngles.y; // absolute rotation für instantiation
            Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
