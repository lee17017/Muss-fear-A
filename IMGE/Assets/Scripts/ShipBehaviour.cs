using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {
    private Vector3 Ziel;
    private Vector3 nextZiel;
    private int Zielcounter = 2;
    private GameObject CameraBase;
    private float FullDistance;
	// Use this for initialization
	void Start () {
        Ziel = GameObject.Find("Position0").transform.position;
        nextZiel = GameObject.Find("Position1").transform.position;
        CameraBase = GameObject.Find("CameraBase");
        FullDistance = Vector2.Distance(new Vector2(gameObject.transform.position.x, gameObject.transform.position.z), new Vector2(Ziel.x, Ziel.z));
	}
	
	// Update is called once per frame
	void Update () {
        //Camerabewegung
        //CameraBase.transform.Rotate(new Vector3(0, 0.1f, 0), Space.World);

        //Bewegung
        Vector3 tmp = gameObject.transform.position;
        float Distance = Vector2.Distance(new Vector2(tmp.x, tmp.z), new Vector2(Ziel.x, Ziel.z));
        if(Distance<3){
            Ziel=nextZiel;
            nextZiel=GameObject.Find("Position"+(Zielcounter%10)).transform.position;
            Zielcounter++;
            FullDistance = Vector2.Distance(new Vector2(tmp.x, tmp.z), new Vector2(Ziel.x, Ziel.z));
        }
        //Ausrichten
        //Einfacher Weg: transform.LookAt(Ziel);
        Quaternion ausrichten = Quaternion.LookRotation(new Vector3(Ziel.x, 0f, Ziel.z) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, ausrichten, Time.deltaTime*2);
        
        transform.Translate(Vector3.forward * 20 * Time.deltaTime, Space.Self);

    }
}
