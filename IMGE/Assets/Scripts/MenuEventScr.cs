using UnityEngine;
using System.Collections;

public class MenuEventScr : MonoBehaviour {
    
    public GameObject Asteroid;
    public GameObject Enemy;
    public GameObject Player;
    private bool spawn=true;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    //Menü-Spawning
        if (spawn)
        {
            spawn = false;
            GameObject tmp=Instantiate(Asteroid,new Vector3(1000,0,Random.Range(-200, 200)),Quaternion.identity);
            tmp.GetComponent<Rigidbody>().velocity = new Vector3(-50, 0, 0);
            StartCoroutine(Spawn());
        }
        
    }

    private Vector3 FindRandomPos()
    {
        Vector3 rand = Random.onUnitSphere;
        return new Vector3(rand.x*1000,0,rand.z);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        spawn = true;
    }
}
