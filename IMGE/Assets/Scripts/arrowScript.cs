using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {

    public GameObject player, goal;
    private float x, z;
	// Use this for initialization
	void Start () {

         x = goal.transform.position.x;
         z = goal.transform.position.z;
            }
	
	// Update is called once per frame
	void Update () {
        float dX = x - player.transform.position.x;
        float dZ = z - player.transform.position.z;

        float temp = Mathf.Atan(dZ / dX) / Mathf.PI * 180;
        if (dX > 0)
        {
            Debug.Log(temp);
            temp = temp - 90;
        }
        else
            temp += 90;
        this.transform.rotation = Quaternion.Euler(0,0, temp);
    }
}
