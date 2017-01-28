using UnityEngine;
using System.Collections;

public class AsteroidBehaviour : MonoBehaviour {
	public float speed;
    public int HP;
    // Use this for initialization
	void Start () {
	}

    // Update is called once per frame
	void Update () {
        Move();
	}
    
    public void Spawn(float x, float y, float speed)
    {

    }
	
    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bullet")
        {

            Destroy(col.gameObject);
            HP -= 7;
        }
        else if (col.tag == "Asteroid" && HP <= col.GetComponent<AsteroidBehaviour>().HP)
        {
            Destroy(this.gameObject);
        }

        if (HP <= 0)
            Destroy(this.gameObject);
    }

}
