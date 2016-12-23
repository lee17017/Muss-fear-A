using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {
    private Vector3 Ziel;
    private Vector3 nextZiel;
    private int Zielcounter = 2;
    private GameObject CameraBase;

	// Use this for initialization
	void Start () {
        Ziel = GameObject.Find("Position0").transform.position;
        nextZiel = GameObject.Find("Position1").transform.position;
        CameraBase = GameObject.Find("CameraBase");
	}
	
	// Update is called once per frame
	void Update () {
        //Bewegung
        Vector3 tmp = gameObject.transform.position;
        float Distance = Vector2.Distance(new Vector2(tmp.x, tmp.z), new Vector2(Ziel.x, Ziel.z));
        if(Distance<5){
            Ziel=nextZiel;
            nextZiel=GameObject.Find("Position"+(Zielcounter%10)).transform.position;
            Zielcounter++;
        }
        //Ausrichten
        //Einfacher Weg: transform.LookAt(Ziel);
        Quaternion ausrichten = Quaternion.LookRotation(new Vector3(Ziel.x, Ziel.y, Ziel.z) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, ausrichten, Time.deltaTime);
        
        transform.Translate(Vector3.forward * 20 * Time.deltaTime, Space.Self);

    }
    void LateUpdate()
    {
        //Camerabewegung
        Debug.Log(gameObject.transform.position.x);
        CameraBase.transform.LookAt(gameObject.transform);
    }
}
