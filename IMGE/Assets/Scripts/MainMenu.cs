using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Button Multiplayer;
    public Button Singleplayer;
    public Button Help;
    public Button Quit;
    public Button Options;
    public Button Return;
    public Button Zurück;
    public Button Weiter;
    public Image Player1;
    public Image Player2;
    public Image Player3;
    public Image Player4;

	// Use this for initialization
	void Start () {
        Multiplayer.gameObject.SetActive(true);//Multiplayer aktivieren
        Singleplayer.gameObject.SetActive(true);//Singleplayer aktivieren
        Help.gameObject.SetActive(true);//Help Aktivieren
        Quit.gameObject.SetActive(true);//Quit aktivieren
        Options.gameObject.SetActive(true);//Options aktivieren
        Return.gameObject.SetActive(false);//Sprungbuttons deaktivieren
        Zurück.gameObject.SetActive(false);
        Weiter.gameObject.SetActive(false);
        Player1.gameObject.SetActive(false);//Images deaktivieren
        Player2.gameObject.SetActive(false);
        Player3.gameObject.SetActive(false);
        Player4.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void MainButtons(int ButtonID)
    {
        //MainButtons deaktivieren + Return aktivieren
        if (ButtonID != 5 && ButtonID != 0)
        {
            Multiplayer.gameObject.SetActive(false);
            Singleplayer.gameObject.SetActive(false);
            Help.gameObject.SetActive(false);
            Quit.gameObject.SetActive(false);
            Options.gameObject.SetActive(false);
            Return.gameObject.SetActive(true);
        }
        
        switch (ButtonID)//Entsprechende Buttons/Bilder freischalten
        {
            case 1://Help
                //Text aktivieren                                                                       !!!!!
                //Schaltflächen aktivieren
                Zurück.gameObject.SetActive(true);
                Weiter.gameObject.SetActive(true);
                break;
            case 2://Options
                //Optionenbuttons aktivieren                                                            !!!!!
                break;
            case 3://Singleplayer
                //Image Player1 aktivieren und in Mitte positionieren                                   !!!!!
                Player1.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Player1.gameObject.SetActive(true);
                break;
            case 4://Multiplayer
                //Player1 auf Position setzen
                Player1.GetComponent<RectTransform>().localPosition = new Vector3(-75, 75, 0);
                //Images aktivieren
                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(true);
                Player3.gameObject.SetActive(true);
                Player4.gameObject.SetActive(true);
                break;
            case 5://Return
                //Zu Main wechseln
                Multiplayer.gameObject.SetActive(true);
                Singleplayer.gameObject.SetActive(true);
                Help.gameObject.SetActive(true);
                Quit.gameObject.SetActive(true);
                Options.gameObject.SetActive(true);
                Return.gameObject.SetActive(false);
                //Andere Buttons deaktivieren
                Zurück.gameObject.SetActive(false);
                Weiter.gameObject.SetActive(false);
                //Images deaktivieren
                Player1.gameObject.SetActive(false);
                Player2.gameObject.SetActive(false);
                Player3.gameObject.SetActive(false);
                Player4.gameObject.SetActive(false);
                break;
            case 6://Zurück
                //Seitenumschalten rückwärts
                break;
            case 7://weiter
                //Seitenumschalten vorwärts
                break;
            default://Quit
                //System.quit(0);
                break;
        }
        
        
        
    }
}
