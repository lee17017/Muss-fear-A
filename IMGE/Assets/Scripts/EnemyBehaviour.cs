using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    private int HitpointsMax;           //Maximale Lebenspunkte
    private float HPis;                 //Aktuelle Lebenspunkte
    private GameObject PatrolNext;      //Für vorgegebene Flugstrecken
    private GameObject Projectile;      //Referenz auf Geschosstyp
    private GameObject Player;          //Referenz auf Spielerschiff
    
	// Use this for initialization
	void Start () {
	
	}
    public void SpawnEnemy(int HP, GameObject PatrolStart, GameObject Projectile, GameObject Player)//Zum Initialisieren beim Spawnen
    {
        HPis = HitpointsMax = HP;
        PatrolNext = PatrolStart;
        this.Projectile = Projectile;
        this.Player = Player;
    }
	// Update is called once per frame
	void Update () {
        Fly();
	}

    //Flugbahn einhalten //TODO
    void Fly()
    {
        if (PatrolNext)
        {
            //Auf Ziel zubewegen
        }
    }

    //Unterbrechung wenn Spieler/gefährliche Obstacles in Reichweite
    void CheckForAlarm()
    {
        //Checken ob Gefahr in der Nähe
        //Asteroid->Ausweichen
        //Spieler ->Angreifen
    }

    //Collision //TODO
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
        else if (other.gameObject.tag == "Asteroid")
        {

        }
    }
}
