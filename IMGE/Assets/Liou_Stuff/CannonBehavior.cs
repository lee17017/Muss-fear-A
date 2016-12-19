using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour {
    public bool controller = false;
    public float rotateSpeed=50f;
    public float deadAngle=30f;
    public GameObject bullet;

    private GameObject bulletSpawnPoint;
    private int playerNr = 1;//2.Player
	void Start () {
        bulletSpawnPoint = GameObject.Find("BulletSpawnPoint");

        if(controller)
            InputManager.Init(playerNr);
	}
    
	void Update () {
        
        float curLocRot = transform.localRotation.eulerAngles.y; // EulerAngles gehn von 0 bis 360 => -0 bis -180 wird auf 360 bis 180 gemapp
        float curRot = transform.rotation.eulerAngles.y; // absolute rotation für instantiation

        if (controller)
        {
            //Rotieren
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, InputManager.Analog(playerNr,1),0), Time.time * rotateSpeed);

            //Schießen
            if(InputManager.Pressed(playerNr,3))
                Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
        }
        else
        {
            //Rotation der Kanone in einem Bereich
            float tmp = Input.GetAxis("Horizontal");          

            if ((tmp > 0 && (curLocRot < 180 - deadAngle || curLocRot > 180)) || (tmp < 0 && (curLocRot > 180 + deadAngle || curLocRot < 180)))
                transform.Rotate(new Vector3(0, tmp, 0) * Time.deltaTime * rotateSpeed);


            //Schießen
            if (Input.GetKeyDown("space")) // muss zu GetKeyDown werden aber so ist grad lustiger
            {
                Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
            }
        }

    }
}
