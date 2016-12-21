using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StateUpdater : MonoBehaviour {
    /*Gebrauch:
     * Speichert Werte wie HP und Munition
     * Updatet davon abhängig die Anzeigen am Bildschirm
     * 
     */
    private static int HP;//Muss 0-100 sein
    private static int munition;
    private static int score;
    public static Image Healthbar;
    public static Image Munition;
    public static Text Score;

	// Use this for initialization
	static void Start () {
		//Einstellen von Anzeigen (wäre hier schöner)
        
        //Test
        test();
	}
	
	// Update is called once per frame
	static void Update () {
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
        Munition.rectTransform.localScale.Set(munition, 20, 0);
        Munition.rectTransform.localPosition.Set(390f-(munition-6.4f)/2, -212f, 0f);

        //Score aktualisieren
        //TODO
    }
    private static void test()
    {
        HP = 100;
        munition = 30;
        score = 0;
    }
    private static void test2()
    {
        if (Input.GetButtonDown("SPACE"))
        {
            UpdateStats(0, -1, 0);
        }
    }
}
