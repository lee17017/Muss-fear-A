using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    int speed = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = this.transform.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    position.x--;
            
        }
    
     else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
           
            position.x++;


        }else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.y++;
           
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y--;
            
        }
        this.transform.position = position;
    }
}
