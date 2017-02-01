using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {

    public GameObject player;

    public GameObject explosion;
    public GameObject[] cps;
    private PlayerBehaviour playerScript;
    private float x, z;
    private int max, act;
    public bool boss = false;
    private bool once = true;
    private float rotSpeed = 20f;
	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<PlayerBehaviour>();
        max = cps.Length;
         x = cps[0].transform.position.x;
         z = cps[0].transform.position.z;
        act = 0;
        for (int i = 1; i < max; i++)
        {
            cps[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (playerScript.checkPointNr >= max && once)
        {
            once = false;
            Debug.Log("Win");
            StartCoroutine("kaboom");
        }
        if (boss && once)
        {
            x = cps[act].transform.position.x;
            z = cps[act].transform.position.z;
        }
        if (playerScript.checkPointNr != act && playerScript.checkPointNr < max)
        {
            act = playerScript.checkPointNr;
            cps[act].SetActive(true);
            x = cps[act].transform.position.x;
            z = cps[act].transform.position.z;
        }
  

        if (once)
        {
            float dX = x - player.transform.position.x;
            float dZ = z - player.transform.position.z;

            float temp = Mathf.Atan(dZ / dX) / Mathf.PI * 180;
            if (dX > 0)
            {
                temp = temp - 90;
            }
            else
                temp += 90;

            this.transform.rotation = Quaternion.Euler(0, 0, temp);
        }
    }

    IEnumerator kaboom()
    {

        for (int i = 0; i < 70; i++)
        {
            if (i % 10 == 0)
            {
                rotSpeed += i;
            }
            this.transform.Rotate(Vector3.forward, rotSpeed);
            yield return new WaitForSeconds(0.05f);
        }
        GameObject temp = Instantiate(explosion);
       
        temp.transform.position = player.transform.position + new Vector3(61.5f,0,30);
        temp.GetComponent<ParticleSystem>().startSize = 6;


        temp.GetComponent<ParticleSystem>().startLifetime = 2;
        Destroy(this.gameObject);

    }
    
}
