﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
    public int HPMax=700;
    public int HP = 700;
    private Vector3 Ziel;
    private Vector3 nextZiel;
    private int Zielcounter = 2;
    public GameObject player;
    public bool change = true;
    private int triggerPoint;
    public GameObject shield;
    public bool triggered;
    public float blowTime=0;
    private bool once = true;
    public Text text;
    public GameObject explosion;
    public GameObject wahhhh;
    public Image HealthbarR;
    public Image HealthbarY;
    public float textTimer;
    // Use this for initialization
    void Start()
    {
        triggered = false;
        triggerPoint = HP / 2;
        Ziel = GameObject.Find("Position0").transform.position;
        nextZiel = GameObject.Find("Position1").transform.position;
        StartCoroutine(SwitchPos());
    }

    IEnumerator textBlinking()
    {
        for (int i = 0; i < 3; i++)
        {
            text.text = "Gunner BLOW his shield away";
            yield return new WaitForSeconds(1f);
            text.text = "";
            yield return new WaitForSeconds(0.5f);
            textTimer = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerBehaviour>().playing)
            Bewegung();
        if (triggered)
        {
            textTimer += Time.deltaTime;

            if (blowTime < 0.1f && textTimer > 30.0f)
            {
                textTimer = 0;
                StartCoroutine("textBlinking");
            }
            if(blowTime>0.1f)
            {
                StopCoroutine("textBlinking");
                text.text = "";
            }
            if (InputManager.blow(1) > 4000 && Vector3.Distance(this.transform.position, player.transform.position) < 150)
            {
                blowTime += Time.deltaTime;
            }
            if (blowTime > 2)
            {
                shield.SetActive(false);
                triggered = false;
            }
            else if (blowTime > 1.5)
                shield.GetComponent<ParticleSystem>().emissionRate = 100;
            else if (blowTime > 1)
                shield.GetComponent<ParticleSystem>().emissionRate = 200;
            else if(blowTime > 0.5f)
                shield.GetComponent<ParticleSystem>().emissionRate = 500;
            Debug.Log(blowTime);
        }


        if (HP < triggerPoint && !triggered && once)
        {
            shield.SetActive(true);
            triggered = true;
            once = false;
        }



    }
    private void Bewegung()
    {
        HealthbarR.gameObject.SetActive(true);
        HealthbarY.gameObject.SetActive(true);
        //Bewegung
        Vector3 tmp = gameObject.transform.position;
        float Distance = Vector2.Distance(new Vector2(tmp.x, tmp.z), new Vector2(Ziel.x, Ziel.z));
        if (Distance < 10)
        {
            Ziel = nextZiel;
            nextZiel = GameObject.Find("Position" + (Zielcounter % 10)).transform.position;
            Zielcounter++;
            StopAllCoroutines();
            StartCoroutine(SwitchPos());
        }
        //Ausrichten
        //Einfacher Weg: transform.LookAt(Ziel);
        Quaternion ausrichten = Quaternion.LookRotation(new Vector3(Ziel.x, Ziel.y, Ziel.z) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, ausrichten, Time.deltaTime);

        transform.Translate(Vector3.forward * 15 * Time.deltaTime, Space.Self);
    }
    IEnumerator SwitchPos()
    {
        yield return new WaitForSeconds(8);
        Ziel = nextZiel;
        nextZiel = GameObject.Find("Position" + (Zielcounter % 10)).transform.position;
        Zielcounter++;
        StartCoroutine(SwitchPos());
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            GameObject temp;
            if (HP > 0 && !triggered)
                HP -= 7;
            else if (HP <= 0)
            {
                player.GetComponent<PlayerBehaviour>().checkPointNr = 3;
                 temp = Instantiate(wahhhh);
                temp.transform.position = transform.position;
                temp.GetComponent<ParticleSystem>().startSize = 7;


                temp.GetComponent<ParticleSystem>().startLifetime = 2;
                Destroy(this.gameObject);

            }
            temp = Instantiate(explosion);
            temp.transform.position = col.gameObject.transform.position;
            Destroy(col.gameObject);
            HealthbarY.rectTransform.sizeDelta = new Vector2(200 * (1f * HP / HPMax), 20);//Healthanzeige aktualisieren
        }
    }
    
}
