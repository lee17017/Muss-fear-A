using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    private bool normal = true, cp = true, orbit = true;
    public GameObject asteroid, orbitAst;
    public GameObject player;
    public GameObject arrow;
    // Use this for initialization
    private bool start;
   
    private GameObject[] checkPoints;
	void Start () {
        checkPoints = arrow.GetComponent<arrowScript>().cps;
        start = player.GetComponent<PlayerBehaviour>().playing;
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
        yield return new WaitForSeconds(3.0f);
        normal = true;
    }

    IEnumerator spawnCP()
    {
        cp = false;
        Vector3 rand = Random.onUnitSphere;
        Vector3 rand2 = Random.onUnitSphere;
        Vector3 checkPoit = checkPoints[player.GetComponent<PlayerBehaviour>().checkPointNr].transform.position;
        Vector3 pos1 = new Vector3(rand.x * 1000, 0, rand.z * 1000);
        Vector3 pos2 = new Vector3(checkPoit.x+rand2.x * 100, 0, checkPoit.z+rand2.z * 100);
        GameObject neu = Instantiate(asteroid);
        neu.transform.position = pos1;
        neu.transform.LookAt(pos2);
        
        yield return new WaitForSeconds(3.0f);
        cp = true;
    }
    IEnumerator spawnOrbit()
    {
        orbit = false;
        for (int i = 0; i < 14; i++)
        {
            Vector3 checkPoit = checkPoints[player.GetComponent<PlayerBehaviour>().checkPointNr].transform.position;
            GameObject temp = Instantiate(orbitAst);
            temp.transform.position = checkPoit;
            temp.transform.GetComponent<AsteroidOrbit>().HP++;
            yield return new WaitForSeconds(0.2f);
            
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
