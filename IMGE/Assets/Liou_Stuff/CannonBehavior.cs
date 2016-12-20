using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour {
    public bool controller = false;
    public float rotateSpeed=50f;
    public float deadAngle=40f;
    public GameObject bullet;
    public int maxMun = 30, actMun;
    public float shootCD = 0.5f, reloadCD = 2;

    private float shootTimer = 0, reloadTimer=0;
    private GameObject bulletSpawnPoint;
    private int playerNr = 1;//2.Player
	void Start () {
        bulletSpawnPoint = GameObject.Find("BulletSpawnPoint");
        actMun = maxMun;
        if(controller)
            InputManager.Init(playerNr);
	}
    
	void Update () {
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;
        if (actMun < 30)
            reloadTimer += Time.deltaTime;

        if(reloadTimer>reloadCD)
        {
            reloadTimer = 0;
            actMun++;
        }
        float curLocRot = transform.localRotation.eulerAngles.y; // EulerAngles gehn von 0 bis 360 => -0 bis -180 wird auf 360 bis 180 gemapp
        float curRot = transform.rotation.eulerAngles.y; // absolute rotation für instantiation

        if (controller)
        {
            //Rotieren
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, InputManager.Analog(playerNr,1),0), Time.time);

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
            if (Input.GetKey("space") && shootTimer <= 0 && actMun > 0) // muss zu GetKeyDown werden aber so ist grad lustiger
            {
                shootTimer = shootCD;
                actMun--;
                Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
            }
        }
    }
}
