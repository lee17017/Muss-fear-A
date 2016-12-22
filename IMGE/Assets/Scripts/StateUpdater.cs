using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateUpdater : MonoBehaviour{
    /*Gebrauch:
     * Speichert Werte wie HP und Munition
     * Updatet davon abhängig die Anzeigen am Bildschirm
     * 
     */
    private static int HP;//Muss 0-100 sein
    private static int munition;
    private static int score;
    private static Image Healthbar;
    private static Image Munition;
    private static Image Score;

	// Use this for initialization
	void Start () {
		//Einstellen von Anzeigen (wäre hier schöner)
        //GameObject tmp=GameObject.Find("Canvas");
        Munition = GameObject.Find("Bullet-State-IMG").GetComponent<Image>();
        //Test
        test();
	}
	
	// Update is called once per frame
	void Update () {
        test2();
	}

    public static void UpdateStats(int deltaHP, int deltaMunition, int deltaScore)
    {
        HP += deltaHP;
        munition += deltaMunition;
        score += deltaScore;

        //Lebensleiste aktualisieren
        //TODO

        //Munitionsleiste aktualisieren

        Munition.rectTransform.sizeDelta = new Vector2(munition*6.4f, 12.8f);
        //Munition.rectTransform.localPosition.Set(390f - (munition*6.4f - 6.4f) / 2, -212f, 0f);
        Munition.rectTransform.Translate(new Vector3((deltaMunition * 6.4f) / 2,0f, 0f));
        //Score aktualisieren
        //TODO
    }
    private static void test()
    {
        HP = 100;
        //munition = 30;
        UpdateStats(0, 30, 0);
        score = 0;
    }
    private static void test2()
    {
        if (Input.GetButtonDown("Jump"))
        {
            UpdateStats(0, -1, 0);
            Debug.Log("Bin da!");
        }
    }
}
