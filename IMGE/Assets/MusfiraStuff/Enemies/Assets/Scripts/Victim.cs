using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Victim : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
   
    public UnityEvent createEnemy;
    GameObject trigger;
    public GameObject enemyPrefab;
    float xPosition = -16.63f;
    float yPosition = 1.5f;
    bool activate = true; 
    void Start()
    {
        
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

    void OnCollisionEnter(Collision col)
    {
        if (transform.position.z < -5) { activate = false;
        } else
        {
            activate = true; 
        }
        if ((col.gameObject.tag == "TriggerZone") && activate==true)
        { 
            

            Debug.Log("Collsion detected!");  //Get gameObject 
             trigger = GameObject.FindGameObjectWithTag("TriggerZone");
            float distance = trigger.transform.position.z - 5;
            for (int i=0; i<6; i++)
            {
                Instantiate(enemyPrefab, new Vector3(xPosition, yPosition, distance), Quaternion.identity);  //Instantiate 5 enemies 
                if(xPosition >= 32) { xPosition = -16.63f; }
                xPosition += 6;
                activate = false;
            }
            
        }


    }

  

}