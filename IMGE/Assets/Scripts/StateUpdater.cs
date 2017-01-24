using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StateUpdater{
    /*Gebrauch:
     * Speichert Werte wie HP und Munition
     * Updatet davon abhängig die Anzeigen am Bildschirm
     * 
     */
    private static int HP=0;
    private static int HPMax;
    private static int munition=0;
    private static int score=0;
    private static Image HealthbarYELLOW;
    private static Image HealthbarGREEN;
    private static Image Munition;
    private static Text Score;



    //---------------------------------------------------------------------------------Setter-------------------------------------------------------------------------------

    public static void setMunition(int muni){
        Munition = GameObject.Find("Bullet-State-IMG").GetComponent<Image>();
       
        UpdateMunition(muni-munition);
    }
    public static void setLife(int LifeMax)
    {
        HealthbarYELLOW = GameObject.Find("LebensbalkenYELLOW").GetComponent<Image>();
        HealthbarGREEN = GameObject.Find("LebensbalkenGREEN").GetComponent<Image>();
        HPMax = LifeMax;
        UpdateLife(LifeMax-HP);
    }
    public static void setScore()
    {
        Score = GameObject.Find("Score").GetComponent<Text>();
    }

    //----------------------------------------------------------------------------------------Update-Methoden----------------------------------------------------------------------


    public static void UpdateMunition(int deltaMunition)
    {
        munition += deltaMunition;
        //Munitionsleiste aktualisieren
        Munition.rectTransform.sizeDelta = new Vector2(munition*6.4f, 12.8f);
        Munition.rectTransform.Translate(new Vector3(-(deltaMunition *(Screen.width/587f)*2.3f),0f, 0f));
        //Munition.rectTransform.localPosition.Set(390f - (munition*6.4f - 6.4f) / 2, -212f, 0f);
        
    }
    public static void UpdateLife(int deltaLife)
    {
        HP += deltaLife;
        //Lebensleiste aktualisieren
        HealthbarGREEN.rectTransform.sizeDelta = new Vector2(200*(1f*HP/HPMax), 20);
        HealthbarGREEN.rectTransform.Translate(new Vector3(deltaLife * (Screen.width / 587f) *0.73f, 0, 0));

    }

    public static void UpdateScore(int deltaScore)
    {
        score += deltaScore;
        //Score aktualisieren
        //TODO
    }

    //------------------------------------------------------------------------------Test-Methoden----------------------------------------------------------------------------

    private static void test()
    {
        HP = 100;
        //munition = 30;
        UpdateMunition(30);
        score = 0;
    }
    private static void test2()
    {
        if (Input.GetButtonDown("Jump"))
        {
            UpdateMunition(-1);
        }
    }
}
