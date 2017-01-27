using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    //public Button Multiplayer;
    public Button Singleplayer;
    public Button Help;
    public Button Quit;
    public Button Options;
    public Button Return;
    public Button Zurück;
    public Button Weiter;
    public Button start;
    public Image Player1;
    public Image Player2;
    public Image Player3;
    public Image Player4;
    public Image Info;
    public Text Infotext;
    public Toggle ShipControl;
    public Toggle CanonControl;
    private int Infopage;


	// Use this for initialization
	void Start () {
        //Alles voreingestellt...
        //Multiplayer.gameObject.SetActive(true);//Multiplayer aktivieren
        //Singleplayer.gameObject.SetActive(true);//Singleplayer aktivieren
        //Help.gameObject.SetActive(true);//Help Aktivieren
        //Quit.gameObject.SetActive(true);//Quit aktivieren
        //Options.gameObject.SetActive(true);//Options aktivieren
        //Return.gameObject.SetActive(false);//Sprungbuttons deaktivieren
        //Zurück.gameObject.SetActive(false);
        //Weiter.gameObject.SetActive(false);
        //Player1.gameObject.SetActive(false);//Images deaktivieren
        //Player2.gameObject.SetActive(false);
        //Player3.gameObject.SetActive(false);
        //Player4.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Infotext.IsActive()==true)
        {
            switch (Infopage)
            {
                case 0:
                    Infotext.text = "Seite1\n\nText...";
                    break;
                case 1:
                    Infotext.text = "Seite2\n\nText...";
                    break;
                case 2:
                    Infotext.text = "Seite3\n\nText...";
                    break;
                case 3:
                    Infotext.text = "Seite4\n\nText...";
                    break;
                case 4:
                    Infotext.text = "Seite5\n\nText...";
                    break;
                default:
                    Infopage = 0;
                    break;
            }
        }
        //Controllersteuerung
        //1 Help 2 Optionen 3 Singleplayer 4 Multiplayer 5 Return 6 zurück 7 weiter 8 start d quit
        if (InputManager.Pressed(0, 1) || InputManager.Pressed(1, 1))//Welche genau muss ausprobiert werden
        {
            //Bei Oben-Button in Spalte/Reihe zurück wechseln (mit Moduloswap)
            //CurserPosition--;
        }
        if (InputManager.Pressed(0, 1) || InputManager.Pressed(1, 2))//Welche genau muss ausprobiert werden
        {
            //Bei Unten-Button in Spalte/Reihe weiter wechseln (mit Moduloswap)
            //CurserPosition++;
        }
        if (InputManager.Pressed(0, 1) || InputManager.Pressed(1, 3))//Welche genau muss ausprobiert werden
        {
            //Bei Links-Button auf Zurück gehen
            //
        }
        if (InputManager.Pressed(0, 1) || InputManager.Pressed(1, 4))//Welche genau muss ausprobiert werden
        {
            //Bei Rechts-Button auf Weiter gehen
            //
        }

        if (InputManager.Pressed(0, 1) || InputManager.Pressed(1, 5))//Welche genau muss ausprobiert werden
        {
            //Durch Bestätigungs-Button ausführen
            //MainButtons(xy);
        }
        //Visualisierung anpassen
	}

    public void MainButtons(int ButtonID)
    {
        //MainButtons deaktivieren + Return aktivieren
        if (ButtonID != 5 && ButtonID != 0)
        {
            //Rausgenommen: Multiplayer.gameObject.SetActive(false);
            Singleplayer.gameObject.SetActive(false);
            Help.gameObject.SetActive(false);
            Quit.gameObject.SetActive(false);
            Options.gameObject.SetActive(false);
            Return.gameObject.SetActive(true);
        }
        //Controllersteuerung Seitenstartpunkt setzen (Play/Zurück)                                     !!!!!
        
        switch (ButtonID)//Entsprechende Buttons/Bilder freischalten
        {
            case 1://Help
                //Text aktivieren                                                                       !!!!!
                //Schaltflächen aktivieren
                Zurück.gameObject.SetActive(true);
                Weiter.gameObject.SetActive(true);
                //Info aktivieren
                Info.gameObject.SetActive(true);
                Infotext.gameObject.SetActive(true);
                Infopage = 0;
                break;
            case 2://Options
                //Optionenbuttons aktivieren                                                            !!!!!
                ShipControl.gameObject.SetActive(true);
                CanonControl.gameObject.SetActive(true);
                break;
            case 3://Singleplayer
                //Image Player1 aktivieren und richtig positionieren (+Pla2)
                Player1.GetComponent<RectTransform>().localPosition = new Vector3(-75, 100, 0);
                Player1.gameObject.SetActive(true);
                Player2.GetComponent<RectTransform>().localPosition = new Vector3(75, -50, 0);
                Player2.gameObject.SetActive(true);
                start.gameObject.SetActive(true);
                break;
            case 4://Multiplayer (rausgenommen)
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
                //Rausgenommen: Multiplayer.gameObject.SetActive(true);
                Singleplayer.gameObject.SetActive(true);
                Help.gameObject.SetActive(true);
                Quit.gameObject.SetActive(true);
                Options.gameObject.SetActive(true);
                
                //Andere Buttons deaktivieren
                Return.gameObject.SetActive(false);
                Zurück.gameObject.SetActive(false);
                Weiter.gameObject.SetActive(false);
                start.gameObject.SetActive(false);
                //Images deaktivieren
                Player1.gameObject.SetActive(false);
                Player2.gameObject.SetActive(false);
                Player3.gameObject.SetActive(false);
                Player4.gameObject.SetActive(false);
                Info.gameObject.SetActive(false);
                //Text deaktivieren
                Infotext.gameObject.SetActive(false);
                //Toggles deaktivieren
                ShipControl.gameObject.SetActive(false);
                CanonControl.gameObject.SetActive(false);
                break;
            case 6://Zurück
                //Seitenumschalten rückwärts
                Infopage--;
                break;
            case 7://weiter
                //Seitenumschalten vorwärts
                Infopage++;
                break;
            case 8://Start
                //Wechsel zu Scene "Playing"
                Application.LoadLevel(1);
                break;
            default://Quit
                Application.Quit();
                break;
        }
    }
}
