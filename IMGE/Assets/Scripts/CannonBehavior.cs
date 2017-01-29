using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Änderungen von Oliver in:
 * Start()
 * Update() -> Schießen
 * 
 * Grund:
 * Munitionsanzeige
 */

public class CannonBehavior : MonoBehaviour {
    public bool controller = false;
    public float rotateSpeed=50f;
    public float deadAngle=40f;
    public GameObject bullet;
    public int maxMun = 30, actMun;
    private bool reloading = false;
    public float shootCD = 0.5f, reloadCD = 2, pressReloadCD = 10;
    public GameObject rTXT;
    private Text reloadTxt;
    private float shootTimer = 0, reloadTimer=0, pressReloadTimer =0;
    public GameObject bulletSpawnPoint;
    private int playerNr = 1;//2.Player

	void Start () {
      
        actMun = maxMun;
        if(controller)
            controller = InputManager.Init(playerNr);


        reloadTxt = rTXT.GetComponent<Text>();
        //Olivers Part
        StateUpdater.setMunition(maxMun);
        //
	}
    
	void Update () {
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;
        if (actMun < 30)
            reloadTimer += Time.deltaTime;

      /*  if(reloadTimer>reloadCD)
        {
            reloadTimer = 0;
            actMun++;
            //Olivers Part
            StateUpdater.UpdateMunition(1);//Oder mit Button -> Refill all
            //
        }
        */

 

        
        float curLocRot = transform.localRotation.eulerAngles.y; // EulerAngles gehn von 0 bis 360 => -0 bis -180 wird auf 360 bis 180 gemapp
        float curRot = transform.rotation.eulerAngles.y; // absolute rotation für instantiation

        if (controller)
        {
            //Rotieren
            Quaternion newAnlge = Quaternion.Euler(0, InputManager.Analog(playerNr, 1), 0);
            Quaternion actAngle = transform.localRotation;
            float act = actAngle.eulerAngles.y;
            float neu = newAnlge.eulerAngles.y;
            if(act > 180 && act < 330 && neu < 180 && neu > 50)
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, (act + 160 - 360), 0), Time.deltaTime * rotateSpeed);
            else if (act < 180 && act > 30 && neu > 180 && neu < 310)
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, (act - 160 + 360), 0), Time.deltaTime * rotateSpeed);
            else 
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, newAnlge, Time.deltaTime * rotateSpeed);



            //Schießen
            if (InputManager.Pressed(playerNr, 2) && shootTimer  <= 0 && actMun > 0 && !reloading)
            {
                shootTimer = shootCD;
                actMun--;

                //Olivers Part
                StateUpdater.UpdateMunition(-1);
                //
                Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));
            }
            else if ((InputManager.Pressed(playerNr, 4) && !reloading))
            {
                StartCoroutine("reload");
            }
        }
        else
        {
            //Rotation der Kanone in einem Bereich
            float tmp = Input.GetAxis("Horizontal");
            
            if ((tmp > 0 && (curLocRot < 180 - deadAngle || curLocRot > 180)) || (tmp < 0 && (curLocRot > 180 + deadAngle || curLocRot < 180)))
                transform.Rotate(new Vector3(0, tmp, 0) * Time.deltaTime * rotateSpeed);

            

            //Schießen
            if (Input.GetKey("space") && shootTimer <= 0 && actMun > 0 && !reloading) // muss zu GetKeyDown werden aber so ist grad lustiger
            {
                shootTimer = shootCD;
                actMun--;
                Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.Euler(90f, curRot, 0f));

                //Olivers Part
                StateUpdater.UpdateMunition(-1);
                //
            }
            else if (Input.GetKey("r") && !reloading)
            {
                StartCoroutine("reload");
            }
        }
    }
    void OnApplicationQuit()
    {
        if (controller)
        {
            InputManager.outLED(1);
        }
    }
    IEnumerator reload()
    {
        reloading = true;
        reloadTxt.text = "Reloading";
        yield return new WaitForSeconds(pressReloadCD);
        reloadTxt.text = "";
        int diff = maxMun - actMun;
        StateUpdater.UpdateMunition(diff);
        reloading = false;
        actMun = maxMun;
    }
}
