using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public int HP = 900;
    private Vector3 Ziel;
    private Vector3 nextZiel;
    private int Zielcounter = 2;
    bool change = true;
    // Use this for initialization
    void Start()
    {
        Ziel = GameObject.Find("Position0").transform.position;
        nextZiel = GameObject.Find("Position1").transform.position;
        StartCoroutine(SwitchPos());
    }

    // Update is called once per frame
    void Update()
    {
        Bewegung();


    }
    private void Bewegung()
    {
        //Bewegung
        Vector3 tmp = gameObject.transform.position;
        float Distance = Vector2.Distance(new Vector2(tmp.x, tmp.z), new Vector2(Ziel.x, Ziel.z));
        if (Distance < 10)
        {
            Ziel = nextZiel;
            nextZiel = GameObject.Find("Position" + (Zielcounter % 10)).transform.position;
            Zielcounter++;
            StopAllCoroutines();
            StartCoroutine(SwitchPos());
        }
        //Ausrichten
        //Einfacher Weg: transform.LookAt(Ziel);
        Quaternion ausrichten = Quaternion.LookRotation(new Vector3(Ziel.x, Ziel.y, Ziel.z) - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, ausrichten, Time.deltaTime);

        transform.Translate(Vector3.forward * 15 * Time.deltaTime, Space.Self);
    }
    IEnumerator SwitchPos()
    {
        yield return new WaitForSeconds(8);
        Ziel = nextZiel;
        nextZiel = GameObject.Find("Position" + (Zielcounter % 10)).transform.position;
        Zielcounter++;
        StartCoroutine(SwitchPos());
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {
            if (HP > 0)
                HP -= 7;

            Destroy(col.gameObject);
            Debug.Log(HP);
        }
    }
}
