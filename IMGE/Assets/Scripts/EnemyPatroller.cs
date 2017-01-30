using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : MonoBehaviour {

    public GameObject[] positions;
    private int position = 0;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Bewegung();
	}
    private void Bewegung()
    {
        //Bewegung
        Vector3 tmp = gameObject.transform.position;
        float Distance = Vector2.Distance(new Vector2(tmp.x, tmp.z), new Vector2(positions[position].transform.position.x, positions[position].transform.position.z));
        if (Distance < 10)
        {
            position = (position + 1) % positions.Length ;
        }
        //Ausrichten
        //Einfacher Weg: transform.LookAt(Ziel);
        Quaternion ausrichten = Quaternion.LookRotation(positions[position].transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, ausrichten, Time.deltaTime);

        transform.Translate(Vector3.forward * 30 * Time.deltaTime, Space.Self);
    }

}
