﻿using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

    private float lspeed = 2;
    private float bspeed = 4;
    private Vector2 PlayerPos;
    private Vector2 LastPos;
    private Vector3 Direction=Vector3.zero;
    public GameObject[] lStar = new GameObject[9];
    public GameObject[] bStar = new GameObject[9];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //float amtToMove = lspeed * Time.deltaTime;
        for (int i = 0; i < 9; i++)
        {
            lStar[i].gameObject.transform.Translate(Direction * lspeed * Time.deltaTime, Space.World);
            bStar[i].gameObject.transform.Translate(Direction * bspeed * Time.deltaTime, Space.World);

            float lxDistance = lStar[i].transform.position.x-PlayerPos.x;
            float lyDistance = lStar[i].transform.position.z-PlayerPos.y;
            float bxDistance = bStar[i].transform.position.x-PlayerPos.x;
            float byDistance = bStar[i].transform.position.z-PlayerPos.y;
            if (lxDistance > 150)//Größer x
            {
                lStar[i].transform.position = new Vector3(lStar[i].transform.position.x - 360, -5, lStar[i].transform.position.z);//Sollte passen
            }
            if (lxDistance < -150)//Kleiner x
            {
                lStar[i].transform.position = new Vector3(lStar[i].transform.position.x + 360, -5, lStar[i].transform.position.z);//Sollte passen
            }
            if (lyDistance > 150)//Größer z
            {
                lStar[i].transform.position = new Vector3(lStar[i].transform.position.x, -5, lStar[i].transform.position.z - 270);//Sollte passen
            }
            if (lyDistance < -150)//Kleiner z
            {
                lStar[i].transform.position = new Vector3(lStar[i].transform.position.x, -5, lStar[i].transform.position.z + 270);//Sollte passen
            }

            if (bxDistance > 150)//Größer x
            {
                bStar[i].transform.position = new Vector3(bStar[i].transform.position.x - 270, -5, bStar[i].transform.position.z);//Sollte passen
            }
            if (bxDistance < -150)//Kleiner x
            {
                bStar[i].transform.position = new Vector3(bStar[i].transform.position.x + 270, -5, bStar[i].transform.position.z);//Sollte passen
            }
            if (byDistance > 150)//Größer z
            {
                bStar[i].transform.position = new Vector3(bStar[i].transform.position.x, -5, bStar[i].transform.position.z - 360);//Sollte passen
            }
            if (byDistance < -150)//Kleiner z
            {
                bStar[i].transform.position = new Vector3(bStar[i].transform.position.x, -5, bStar[i].transform.position.z + 360);//Sollte passen
            }
        }
        //Direction = Vector3.zero;
    }
    public void givePos(Vector3 Pos, Vector3 Last)
    {
        PlayerPos=new Vector2(Pos.x,Pos.z);
        LastPos = new Vector2(Last.x, Last.z);
        Direction = new Vector3(PlayerPos.x - LastPos.x,0,PlayerPos.y-LastPos.y);
    }
}
