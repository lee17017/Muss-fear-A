using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemParent : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.GetChildCount() <= 3)
        {
            player.GetComponent<PlayerBehaviour>().checkPointNr++;
            Destroy(this.gameObject);
        }
	}
}
