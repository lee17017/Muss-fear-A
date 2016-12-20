
using UnityEngine;
using System.Collections;


public class PlayerBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
	}

    void getInput()
    {
        int in1, in2;
        in1 = in2 = 0;
        //Maussteuerung
        if (Input.GetButton("Fire2"))
        {
            in1 = 1;
        }
        if(Input.GetButton("Fire1"))
        {
            in2 = 1;
        }
        //Kontrollersteuerung
        in1=InputManager.Analog(0,3);
        in2 = InputManager.Analog(0, 4);
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
        float roty = (gameObject.transform.eulerAngles.y)%360;
        if (roty < 0)
        {
            roty += 360;
        }
        float sin = Mathf.Sin(roty);
        float cos = Mathf.Cos(roty);
        Debug.Log(roty+" Sinus:"+sin+" Cosinus:"+cos);
        if (sin < 0)
        {
            sin *= -1;
        }
        if (cos < 0)
        {
            cos *= -1;
        }
        transform.Translate(-Vector3.forward/*(sin, 0, cos)-gameObject.transform.forward*/ * (in1 + in2) * 5 * Time.deltaTime,Space.Self);
    }
}
