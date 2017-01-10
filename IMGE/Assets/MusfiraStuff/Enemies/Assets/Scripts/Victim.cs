using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Victim : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
   
    public UnityEvent createEnemy;
     

    void Start()
    {
        UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {  //TODO wenn Spieler eine gewisse Zeit überschritten hat, wird ein Enemy erstellt
        //einmal soll eine random Zeit erstellt werden
        
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if(SpawnBehaviour.timer>= SpawnBehaviour.randomTime)
        {
            createEnemy.Invoke();
        }
    }

  

}