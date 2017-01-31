
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

    private Rigidbody rb;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;
    GameObject trigger;
    public GameObject enemyPrefab;
    float xPosition = -50f;
    float yPosition = 1.5f;
    bool activate = true;

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
        text.text = "Setzte Getriebe auf 0";
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
        transform.Translate(-Vector3.forward * (in1 + in2) * 5 * Time.deltaTime,Space.Self);
    }

    public void takeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0)
            SceneManager.LoadScene("Endscene");
        //Changed
        StateUpdater.UpdateLife(-damage);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "TriggerZone")
        {
            Debug.Log("Hit TriggerZone");
            TriggerZone tz = new TriggerZone();

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


            Debug.Log("Watch out");
            // enemyPrefab.transform.position += Time.deltaTime * Vector3.forward;

        }
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
        else if (col.tag == "EnemyBullet")
        {
            takeDamage(3);
            Destroy(col.gameObject);
        }
        else if (col.tag == "BallofDoom")
        {
            takeDamage((playerHP/2));
            Destroy(col.gameObject);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (transform.position.z < -5) { activate = false; }
        else
        {
            activate = true;
        }
        
        if ((col.gameObject.tag == "TriggerZone") && activate == true)
        {


            Debug.Log("Collsion detected!");  //Get gameObject 
            trigger = GameObject.FindGameObjectWithTag("TriggerZone");
            float distance = trigger.transform.position.z - 5;
            for (int i = 0; i < 6; i++)
            {
                Instantiate(enemyPrefab, new Vector3(xPosition, yPosition, distance), Quaternion.identity);  //Instantiate 5 enemies 
                if (xPosition >= 50) { xPosition = -50; }
                xPosition += 6;
                activate = false;
            }

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
