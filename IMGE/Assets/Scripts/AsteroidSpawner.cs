using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    private bool normal = true, cp = true;
    public GameObject asteroid;
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
    // Update is called once per frame
    void Update () {
        if (start)
        {
            if (normal)
                StartCoroutine("spawnNormal");
            else if (cp)
                StartCoroutine("spawnCP");
        }
        else
            start = player.GetComponent<PlayerBehaviour>().playing;
    }
}
