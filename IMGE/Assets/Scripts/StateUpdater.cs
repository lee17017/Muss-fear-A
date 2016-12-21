using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateUpdater : MonoBehaviour {
    /*Gebrauch:
     * Speichert Werte wie HP und Munition
     * Updatet davon abhängig die Anzeigen am Bildschirm
     * 
     */
    int HP;//Muss 0-100 sein
    int munition;
    int score;
    public Image Healthbar;
    public Image Munition;
    public Text Score;

	// Use this for initialization
	void Start () {
		//Einstellen von Anzeigen (wäre hier schöner)
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScore(int deltaHP, int deltaMunition, int deltaScore)
    {
        HP += deltaHP;
        munition += deltaMunition;
        score += deltaScore;
        //Lebensleiste aktualisieren

        //Munitionsleiste aktualisieren
        Munition.rectTransform.localScale.Set(HP, 20, 0);//Noch Position setzen
        Munition.rectTransform.localPosition.Set(345.5f+30-munition, -212f, 0f);
        //Score aktualisieren
    }
}
