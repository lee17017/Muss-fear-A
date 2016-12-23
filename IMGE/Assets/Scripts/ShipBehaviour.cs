using UnityEngine;
using System.Collections;

public class ShipBehaviour : MonoBehaviour {
    private Vector3 Ziel;
    private Vector3 nextZiel;
    private int Zielcounter = 2;
	// Use this for initialization
	void Start () {
        Ziel = GameObject.Find("Position0").transform.position;
        nextZiel = GameObject.Find("Position1").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tmp = gameObject.transform.position;
        if(Vector2.Distance(new Vector2(tmp.x,tmp.z),new Vector2(Ziel.x,Ziel.z))<1){
            Ziel=nextZiel;
            nextZiel=GameObject.Find("Position"+(Zielcounter%10)).transform.position;
            Zielcounter++;
        }
        transform.LookAt(Ziel);
        transform.Translate(Vector3.forward * 10 * Time.deltaTime, Space.Self);

    }
}
