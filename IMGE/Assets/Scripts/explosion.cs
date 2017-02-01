using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
    private GameObject player;
	// Use this for initialization
	void Start () {
        
        if (GameData.playing)
        {
            player = GameObject.Find("Playership");
            float dist = Vector3.Distance(player.transform.position, this.transform.position);
            
            if (dist > 100)
            {
                GetComponent<AudioSource>().enabled = false;
            }
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
