using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCannon : MonoBehaviour {

    public GameObject player, bullet;
    // Use this for initialization
    private GameObject[] children;
    public float timerCD;
    private float timer=0;
    private int start;
    public Image HealthbarR;
    public Image HealthbarY;

    void Start () {
        children = new GameObject[transform.childCount];
        for(int i =0; i<transform.childCount; i++)
            children[i] = transform.GetChild(i).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
    
  
        timer -= Time.deltaTime;
        int links = 0;
        int rechts = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i].transform.LookAt(player.transform);
            if (i < 4 && children[i].transform.rotation.y > 0.05 && children[i].transform.rotation.y < 0.95)
                links++;
            else if (i > 3 && children[i].transform.rotation.y < -0.05 && children[i].transform.rotation.y > -0.95)
                rechts++;
        }
        if (timer < 0)
        {
            if (links == 4 && Vector3.Distance(player.transform.position, this.transform.position) < 100)
            {
                start = 0;
                
            }
            else if (rechts == 4 && Vector3.Distance(player.transform.position, this.transform.position) < 100)
            {
                start = 4;
                
            }
            else
            {
                start = 8;
            }

            if (start != 8)
            {
                StartCoroutine("shoot");
                timer = timerCD;
                HealthbarR.gameObject.SetActive(true);
                HealthbarY.gameObject.SetActive(true);
            }
        }
            
        
    }
    IEnumerator shoot()
    {
         for (int j = 0; j < 5; j++)
                {
                    for (int i = start; i < start+4; i++)
                    {
                        Instantiate(bullet, children[i].transform.GetChild(0).transform.position, Quaternion.Euler(90f, children[i].transform.eulerAngles.y, 0f));
                    }
            yield return new WaitForSeconds(0.1f);
                }
    }
}
