using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyer : MonoBehaviour {
    public int HP;
    public float speed;
    
    public GameObject explosion;
    IEnumerator flyAway()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(5);
            speed *= 2;
        }
        yield return new WaitForSeconds(5);

        Destroy(this.gameObject);
    }
    // Use this for initialization
    void Start () {
        StartCoroutine("flyAway");
        HP = Random.Range(20, 40);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {


            Destroy(col.gameObject);
            if (HP > 0)
            {

                HP -= 7;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    void OnDestroy()
    {

        GameObject temp = Instantiate(explosion);
        temp.transform.position = transform.position;
        temp.GetComponent<ParticleSystem>().startSize = 4;


        temp.GetComponent<ParticleSystem>().startLifetime = 1;
    }
}
