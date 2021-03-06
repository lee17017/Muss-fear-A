﻿
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
/*My Changes (Oliver)
 * Einbinden von StateUpdater:
 * -Start
 * -TakeDamage
 */

public class PlayerBehaviour : MonoBehaviour {
    public bool inv = false;
    public GameObject explosion;
    private int PlayerNumber=0;
    public bool controller;
    public int playerHP;
    private Rigidbody rigid;
    public bool playing = false;
    public Text text;
    public int checkPointNr;
    public GameObject Paralax;
	// Use this for initialization
	void Start () {
        controller = GameData.ControllerActive;
        GameData.playing = true;
        if (controller)
            controller = InputManager.Init(PlayerNumber);
        playerHP = 100;//100 start HP
        rigid = GetComponent<Rigidbody>();

        //Changed
        StateUpdater.reset();
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
        text.text = "Pilot set your engines to zero";
        float in1, in2;
        in1 = in2 = 0;
        in2 = -InputManager.Analog(PlayerNumber, 4);
        in1 = -InputManager.Analog(PlayerNumber, 3);
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
            in1 = -InputManager.Analog(PlayerNumber, 4);
            in2 = -InputManager.Analog(PlayerNumber, 3);
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
        float diff = in1 - in2;
       
        if (in1 < in2)
        {
            diff *= -1;
            gameObject.transform.LookAt(gameObject.transform.position+gameObject.transform.forward-gameObject.transform.right/(20-diff));
        }
        else if(in1>in2)
        {

            gameObject.transform.LookAt(gameObject.transform.position + gameObject.transform.forward + gameObject.transform.right/ (20 - diff));
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
        Vector3 Pos = transform.position;
        transform.Translate(-Vector3.forward * (in1 + in2) * 5 * Time.deltaTime,Space.Self);
        Vector3 Last = transform.position;
        Paralax.gameObject.GetComponent<Stars>().givePos(Pos, Last);//For Paralaxscrolling
    }

    public void takeDamage(int damage)
    {
        if (!inv)
        {
            playerHP -= damage;
            if (playerHP <= 0)
                SceneManager.LoadScene("Endscene");
            //Changed
            StateUpdater.UpdateLife(-damage);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject temp;

        if (col.tag == "Enemy")
        {
            takeDamage(5);
            Destroy(col.gameObject);
            temp = Instantiate(explosion);
            temp.transform.position = col.transform.position;
            temp.GetComponent<ParticleSystem>().startSize = 4;
            temp.GetComponent<ParticleSystem>().startLifetime = 1;

        }
        else if (col.tag == "CP")
        {
            checkPointNr++;
            Destroy(col.gameObject);
        }
        else if (col.tag == "Asteroid")
        {
            temp = Instantiate(explosion);
            temp.transform.position = col.transform.position;
            temp.GetComponent<ParticleSystem>().startSize = 4;
            temp.GetComponent<ParticleSystem>().startLifetime = 1;
            takeDamage(col.GetComponent<AsteroidBehaviour>().HP);
            Destroy(col.gameObject);
        }
        else if (col.tag == "EnemyBullet")
        {
            temp = Instantiate(explosion);
            temp.transform.position = col.transform.position;
            temp.GetComponent<ParticleSystem>().startSize = 4;
            temp.GetComponent<ParticleSystem>().startLifetime = 1;
            takeDamage(3);
            Destroy(col.gameObject);
        }
        else if (col.tag == "BallofDoom")
        {
            temp = Instantiate(explosion);
            temp.transform.position = col.transform.position;
            temp.GetComponent<ParticleSystem>().startSize = 4;
            temp.GetComponent<ParticleSystem>().startLifetime = 1;
            takeDamage((playerHP/2));
            Destroy(col.gameObject);
        }

    }

    void OnApplicationQuit()
    {
        GameData.playing = false;
        if (controller)
        {
            InputManager.outLED(0);
        }
        Debug.Log("QUIT");
    }

 
}
