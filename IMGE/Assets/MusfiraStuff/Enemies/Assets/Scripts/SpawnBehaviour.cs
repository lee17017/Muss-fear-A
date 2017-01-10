using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {
    public GameObject enemyPrefab;
    public int numEnemies;
    public float spawnMin = 1f;
    public float spawnMax = 2f; 
    //Reminder: set an offset; 
    // Use this for initialization
    Enemy enemy;
    bool block = false;
    public static int randomTime;
    public static float timer = 0;

    void Start () {
     //  LinkedList<Enemy> enemyArray = new LinkedList<Enemy>(); //convert into list
        randomTime = Random.Range(0, 5);
        Debug.Log("Random time: "+ randomTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

       if(timer>= randomTime)
        {
            spawn();
            timer = 0;
            block = true;
        }else
        {
            block = false; 
        }
    }

    
   public void spawn()
    {// TODO rand
        float randomOffset = Random.value;
        float spawnX = ((spawnMin + spawnMax) /2) +randomOffset; 
        Instantiate(enemyPrefab, new Vector3(spawnX, transform.position.y, transform.position.z), Quaternion.identity);

           
    }

    
}
