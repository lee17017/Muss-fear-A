﻿
using UnityEngine;
using System.Collections;

using UnityEngine.UI;
/*My Changes (Oliver)
 * Einbinden von StateUpdater:
 * -Start
 * -TakeDamage
 */

public class PlayerBehaviour : MonoBehaviour {
    private int PlayerNumber=0;
    public bool controller;
    public int playerHP;
    private Rigidbody rigid;
    public bool playing = false;
    public Text text;
    public int checkPointNr;
	// Use this for initialization
	void Start () {
        if(controller)
            controller = InputManager.Init(PlayerNumber);
        playerHP = 100;//100 start HP
        rigid = GetComponent<Rigidbody>();

        //Changed
        StateUpdater.setLife(playerHP);
        if (!controller)
            playing = true;

	}
	
	// Update is called once per frame
	void Update () {
        setZero();
        if (playing)
            getInput();
        else
            checkZero();
	}

    void checkZero()
    {
        text.text = "Setzte Getriebe auf 0";
        float in1, in2;
        in1 = in2 = 0;
        in2 = -InputManager.Analog(PlayerNumber, 4);
        in1 = -InputManager.Analog(PlayerNumber, 3);
        Debug.Log("" + in1 + " - " + in2);
        if (in1 > -0.2f && in2 > -0.2f)
        {
            text.text = "";
            playing = true;
        }
    }
    void setZero()
    {
		rigid.velocity = Vector3.zero;
		rigid.angularVelocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x, /*-5f*/0, transform.position.z);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
    void getInput()
    {
        float in1, in2;
        in1 = in2 = 0;
        if (!controller)
        {
            
           if (Input.GetButton("Fire1"))
                in1 = -5;

           if (Input.GetButton("Fire2"))
                in2 = -5;

            //Kontrollersteuerung
        }
        else
        {
            in2 = -InputManager.Analog(PlayerNumber, 4);
            in1 = -InputManager.Analog(PlayerNumber, 3);
            if (in1 >- 0.2f && in2 > -0.2f)
                return;
            if (in1 < -4.9 && in2 < -4.9)
                in1 = in2 = -5;
        }
        
        //Ausführung
        turn(in1,in2);
        move(in1, in2);
    }
    void turn(float in1, float in2)
    {
        if (in1 < in2)
        {
            gameObject.transform.LookAt(gameObject.transform.position+gameObject.transform.forward-gameObject.transform.right/20);
        }
        else if(in1>in2)
        {
            gameObject.transform.LookAt(gameObject.transform.position + gameObject.transform.forward + gameObject.transform.right/20);
        }
    }
    void move(float in1, float in2)
    {
        //float roty = (gameObject.transform.eulerAngles.y)%360;
        //if (roty < 0){roty += 360;}
        //float sin = Mathf.Sin(roty);
        //float cos = Mathf.Cos(roty);
        //Debug.Log(roty+" Sinus:"+sin+" Cosinus:"+cos);
        //Debug.Log(in1 + " " + in2);
        //if (sin < 0){sin *= -1;}
        //if (cos < 0){cos *= -1;}
        transform.Translate(-Vector3.forward * (in1 + in2) * 5 * Time.deltaTime,Space.Self);
    }

    public void takeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
            Debug.Log("DEAD");
        //Changed
        StateUpdater.UpdateLife(-damage);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            takeDamage(5);
            Destroy(col.gameObject);
        }
        else if (col.tag == "CP")
        {
            checkPointNr++;
            Destroy(col.gameObject);
        }
        else if (col.tag == "Asteroid")
        {

            takeDamage(col.GetComponent<AsteroidBehaviour>().HP);
            Destroy(col.gameObject);
        }

    }

    void OnApplicationQuit()
    {
        if (controller)
        {
            InputManager.outLED(0);
        }
        Debug.Log("QUIT");
    }

 
}
