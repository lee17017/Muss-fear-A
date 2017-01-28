using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidOrbit : AsteroidBehaviour {

    public GameObject thing;

    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Rotate(Vector3.up, 2f);
       
    }

}
