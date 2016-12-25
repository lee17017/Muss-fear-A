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
    private static int HP=0;//Muss 0-100 sein
    private static int munition=0;
    private static int score=0;
    private static Image Healthbar;
    private static Image Munition;
    private static Image Score;

	// Use this for initialization
	void Start () {
		//Einstellen von Anzeigen (wäre hier schöner)
        
        //Test
        //test();
	}
	
	// Update is called once per frame
	void Update () {
        //test2();
	}

    public static void setMunition(int muni){
        Munition = GameObject.Find("Bullet-State-IMG").GetComponent<Image>();
        UpdateStats(0, muni-munition, 0);
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
        Munition.rectTransform.Translate(new Vector3(-(deltaMunition *(Screen.width/587f)*2.3f),0f, 0f));//390-munition*3.2
        Debug.Log(Screen.width);
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
        }
    }
}
