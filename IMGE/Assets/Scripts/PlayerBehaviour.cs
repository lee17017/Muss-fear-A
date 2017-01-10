
using UnityEngine;
using System.Collections;
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
	// Use this for initialization
	void Start () {
        if(controller)
            InputManager.Init(PlayerNumber);
        playerHP = 100;//100 start HP
        rigid = GetComponent<Rigidbody>();

        //Changed
        StateUpdater.setLife(playerHP);
	}
	
	// Update is called once per frame
	void Update () {
        setZero();
        getInput();

	}

    void setZero()
    {
		rigid.velocity = Vector3.zero;
		rigid.angularVelocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
    void getInput()
    {
        float in1, in2;
        in1 = in2 = 0;
        if (!controller)
        {
            
           if (Input.GetButton("Fire1"))
                in1 = -3;

           if (Input.GetButton("Fire2"))
                in2 = -3;

            //Kontrollersteuerung
        }
        else
        {
            in2 = -InputManager.Analog(PlayerNumber, 4);
            in1 = -InputManager.Analog(PlayerNumber, 3);
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
        if (playerHP > 0)
            Debug.Log(playerHP);
        else
            Debug.Log("DEAD");
        //Changed
        StateUpdater.UpdateLife(-5);
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
