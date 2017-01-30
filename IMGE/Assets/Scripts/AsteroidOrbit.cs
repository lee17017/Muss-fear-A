using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidOrbit : MonoBehaviour {

    Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position = pos;
        transform.Rotate(Vector3.up, 2f);
       
    }


}
