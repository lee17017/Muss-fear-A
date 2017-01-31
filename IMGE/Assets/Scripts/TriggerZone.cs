using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {

    public float timer=0;
    public float timerCD;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && timer < 0)
        {
            timer = timerCD;
            int spawn = 0;
            Vector3 playerPos = col.transform.position;
            Vector3 thisPos = this.transform.position;
            float xDif = playerPos.x - thisPos.x;
            float zDif = playerPos.z - thisPos.z;
            Vector3 offset, offOffset;
            if (Mathf.Abs(xDif) < Mathf.Abs(zDif))
            {
                if (zDif > 0)
                    spawn = 0;
                else
                    spawn = 1;

                offset = new Vector3(-100, 0, 0);
                offOffset = new Vector3(50, 0, 0);
            }
            else
            {
                if (xDif > 0)
                    spawn = 2;
                else
                    spawn = 3;
                offset = new Vector3(0, 0, -50);

                offOffset = new Vector3(0, 0, 25);
            }
            
            for (int i = 0; i < 5; i++)
            {
                GameObject temp = Instantiate(enemyPrefab);
                temp.transform.position = spawnPoints[spawn].transform.position + offset;
                temp.transform.rotation = spawnPoints[spawn].transform.rotation;
                offset += offOffset;
            }
            /*
                Vector3 position4 = new Vector3(gameObject4.transform.position.x, gameObject4.transform.position.y, gameObject4.transform.position.z);
                Vector3 position5 = new Vector3(gameObject5.transform.position.x, gameObject5.transform.position.y, gameObject5.transform.position.z);
                Vector3 position6 = new Vector3(gameObject6.transform.position.x, gameObject6.transform.position.y, gameObject6.transform.position.z);
                Vector3 position7 = new Vector3(gameObject7.transform.position.x, gameObject7.transform.position.y, gameObject7.transform.position.z);


                GameObject newEnemy;


                for (int i = 0; i < 6; i++)
                {
                    newEnemy = Instantiate(enemyPrefab, position4, Quaternion.Euler(0, 90, 0));
                    position4 = new Vector3(position4.x, position4.y, position4.z + 7);  //in was für Abständen die Enemies gespawnt werden sollen 
                    newEnemy.transform.localScale = new Vector3(-0.08436213f, 0.1176149f, 0.06994853f);  //werden kleiner gescaled
                                                                                                         // Debug.Log();
                    newEnemy.transform.Translate(-Vector3.forward * Time.deltaTime * 4);

                }
                for (int i = 0; i < 6; i++)
                {
                    newEnemy = Instantiate(enemyPrefab, position5, Quaternion.Euler(0, -90, 0));
                    position5 = new Vector3(position5.x + 7, position5.y, position5.z);  //in was für Abständen die Enemies gespawnt werden sollen 
                    newEnemy.transform.localScale = new Vector3(-0.08436213f, 0.1176149f, 0.06994853f);
                    //newEnemy.transform.position += Vector3.left*-enemySpeed * Time.deltaTime;

                }
                for (int i = 0; i < 6; i++)
                {
                    newEnemy = Instantiate(enemyPrefab, position6, Quaternion.Euler(0, -180, 0)) as GameObject;
                    position6 = new Vector3(position6.x + 7, position6.y, position6.z);  //in was für Abständen die Enemies gespawnt werden sollen 
                    newEnemy.transform.localScale = new Vector3(-0.08436213f, 0.1176149f, 0.06994853f);
                    //  newEnemy.transform.position -= Vector3.right * Time.deltaTime;
                }
                for (int i = 0; i < 6; i++)
                {
                    newEnemy = Instantiate(enemyPrefab, position7, Quaternion.Euler(0, 180, 0)) as GameObject;
                    position7 = new Vector3(position7.x, position7.y, position7.z + 7);  //in was für Abständen die Enemies gespawnt werden sollen 
                    newEnemy.transform.localScale = new Vector3(-0.08436213f, 0.1176149f, 0.06994853f);
                    //  newEnemy.transform.position -= Vector3.right * Time.deltaTime;
                }
                */
    
                // enemyPrefab.transform.position += Time.deltaTime * Vector3.forward;

            
        }
    }

}
