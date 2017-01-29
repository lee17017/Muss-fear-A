using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public int HP = 900;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            if (HP > 0)
                HP -= 7;
            
             
            Debug.Log(HP);
        }
    }
}
