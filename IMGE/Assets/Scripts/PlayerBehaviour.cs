﻿
using UnityEngine;
using System.Collections;


public class PlayerBehaviour : MonoBehaviour {
    private int PlayerNumber=0;
    public bool controller;
    public int playerHP;
	// Use this for initialization
	void Start () {
        if(controller)
            InputManager.Init(PlayerNumber);
        playerHP = 100;//100 start HP
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
	}

    void getInput()
    {
        int in1, in2;
        in1 = in2 = 0;
        if (!controller)
        {
            
           if (Input.GetButton("Fire1"))
                in2 = 3;

           if (Input.GetButton("Fire2"))
                in1 = 3;

            //Kontrollersteuerung
        }
        else
        {
            in1 = (int)InputManager.Analog(PlayerNumber, 4);
            in2 = (int)InputManager.Analog(PlayerNumber, 3);
        }
        
        //Ausführung
        turn(in1,in2);
        move(in1, in2);
    }
    void turn(int in1, int in2)
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
    void move(int in1, int in2)
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
        if (playerHP > 0)
            Debug.Log(playerHP);
        else
            Debug.Log("DEAD");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            takeDamage(5);
            Destroy(col.gameObject);
        }

    }
}
