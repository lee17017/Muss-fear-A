﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    private bool normal = true, cp = true, orbit = true;
    public GameObject asteroid, orbitAst;
    public GameObject player;
    public GameObject arrow;
    private int speedSpawn = 0;
    // Use this for initialization
    private bool start;
    public float spwnCD, cpSpwnCD;
    private GameObject[] checkPoints;
	void Start () {
        checkPoints = arrow.GetComponent<arrowScript>().cps;
        start = player.GetComponent<PlayerBehaviour>().playing;
        for (int i = 0; i < 30; i++)
        {
            StartCoroutine("spawnNormal");
            normal = true;
        }
    }

    IEnumerator spawnNormal()
    {
        normal = false;
        Vector3 rand = Random.onUnitSphere;
        Vector3 rand2 = Random.onUnitSphere;
        Vector3 pos1 = new Vector3(rand.x * 1000, 0, rand.z * 1000);
        Vector3 pos2 = new Vector3(rand2.x * 300, 0, rand2.z * 300);
        GameObject neu = Instantiate(asteroid);
        neu.transform.position = pos1;
        neu.transform.LookAt(pos2);
             float x, y, z, sum;

        x = Random.Range(1.0f, 3.0f);
        y = Random.Range(1.0f, 3.0f);
        z = Random.Range(1.0f, 3.0f);
        sum = x + y + z;
        int HP = neu.transform.GetComponent<AsteroidBehaviour>().HP = (int)(sum * 3);
        neu.transform.GetComponent<AsteroidBehaviour>().speed = 100 - HP * 3;
            yield return new WaitForSeconds(spwnCD);
        normal = true;
    }

    IEnumerator spawnCP()
    {
        cp = false;
        if (player.GetComponent<PlayerBehaviour>().checkPointNr < checkPoints.Length)
        {
            
            Vector3 rand = Random.onUnitSphere;
            Vector3 rand2 = Random.onUnitSphere;
            Vector3 checkPoit = checkPoints[player.GetComponent<PlayerBehaviour>().checkPointNr].transform.position;
            Vector3 pos1 = new Vector3(rand.x * 1000, 0, rand.z * 1000);
            Vector3 pos2 = new Vector3(checkPoit.x + rand2.x * 100, 0, checkPoit.z + rand2.z * 100);
            GameObject neu = Instantiate(asteroid);
            neu.transform.position = pos1;
            neu.transform.LookAt(pos2);
            float x, y, z, sum;

            x = Random.Range(1.0f, 3.0f);
            y = Random.Range(1.0f, 3.0f);
            z = Random.Range(1.0f, 3.0f);
            sum = x + y + z;
            int HP = neu.transform.GetComponent<AsteroidBehaviour>().HP = (int)(sum * 3);
            neu.transform.GetComponent<AsteroidBehaviour>().speed = 100 - HP * 3;

            neu.transform.localScale = new Vector3(x, y, z);
        }
            yield return new WaitForSeconds(cpSpwnCD);
        cp = true;
    }
    IEnumerator spawnOrbit()
    {
        orbit = false;
        for (int i = 0; i < 12; i++)
        {
            if (player.GetComponent<PlayerBehaviour>().checkPointNr < checkPoints.Length)
            {
                Vector3 checkPoit = checkPoints[player.GetComponent<PlayerBehaviour>().checkPointNr].transform.position;
                GameObject temp = Instantiate(orbitAst);
                temp.transform.position = checkPoit;
            }
            for (int j = 0; j < 15; j++)
            {
                yield return new WaitForEndOfFrame();
            }

        }
    }
    // Update is called once per frame
    void Update () {
        if (start)
        {
            if (normal)
                StartCoroutine("spawnNormal");
            if (cp)
                StartCoroutine("spawnCP");

            if (orbit && player.GetComponent<PlayerBehaviour>().checkPointNr == 4)
            {
                StartCoroutine("spawnOrbit");
            }
           

        }
        else
            start = player.GetComponent<PlayerBehaviour>().playing;
    }
}
