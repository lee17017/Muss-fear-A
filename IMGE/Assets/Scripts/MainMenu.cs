using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Button Player1;
    public Button Player2;
    public Button Player3;
    public Button Player4;
    public Button Player5;
    public Button Player6;
    public Button Player7;
    public Button Player8;
    public Image Info;
    public Image ConCursor;
    public Text Infotext;
    public Text Title;
    public Toggle ShipControl;
    public Toggle CanonControl;
    private int Infopage;
    private int selection=4;
    private float timer = 1.0f;

	// Use this for initialization
	void Start () {
        GameData.setLevel(0);
        //InputManager.Init(); //Wieder entkommentieren
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
        timer -= Time.deltaTime;
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
        checkConInputs();//Das immer ganz am Ende lassen oder in lateUpdate
	}

    private void checkConInputs()
    {
        if (timer < 0)
        {
            //Controllersteuerung
            if (InputManager.Pressed(0, 1) || InputManager.Pressed(1, 1))
            {
                timer =0.2f;
                //Bei Oben-Button in Reihe zurück wechseln
                if (Singleplayer.IsActive() == true)
                {
                    //Cursor neben Singleplayer setzen
                    Vector2 tmp = Singleplayer.GetComponent<RectTransform>().localPosition;
                    ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x, tmp.y, 0);
                    selection = 4;
                }
                else
                {
                    //Cursor verschieben
                    Vector2 tmp = Player1.GetComponent<RectTransform>().localPosition;
                    selection += 4;
                    selection %= 8;
                    ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x + (selection % 4) * 150, tmp.y - (selection / 4) * 150, 0);
                }
            }
            if (InputManager.Pressed(0, 2) || InputManager.Pressed(1, 2))
            {
                timer =0.2f;
                //Bei Unten-Button in Reihe weiter wechseln
                if (Quit.IsActive() == true)
                {
                    //Cursor neben Quit setzen
                    Vector2 tmp = Quit.GetComponent<RectTransform>().localPosition;
                    ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x, tmp.y, 0);
                    selection = 0;
                }
                else
                {
                    //Cursor verschieben
                    Vector2 tmp = Player1.GetComponent<RectTransform>().localPosition;
                    selection += 4;
                    selection %= 8;
                    ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x + (selection % 4) * 150, tmp.y - (selection / 4) * 150, 0);
                }
            }
            if (InputManager.Pressed(0, 3) || InputManager.Pressed(1, 3))
            {
                timer =0.2f;
                //Bei Links-Button auf Zurück gehen
                if (!Singleplayer.IsActive() == true)
                {
                    //Cursor verschieben
                    Vector2 tmp = Player1.GetComponent<RectTransform>().localPosition;
                    selection += 7;
                    selection %= 8;
                    ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x + (selection % 4) * 150, tmp.y - (selection / 4) * 150, 0);
                }
            }
            if (InputManager.Pressed(0, 4) || InputManager.Pressed(1, 4))
            {
                timer =0.2f;
                //Bei Rechts-Button auf Weiter gehen
                if (!Singleplayer.IsActive() == true)
                {
                    //Cursor verschieben
                    Vector2 tmp = Player1.GetComponent<RectTransform>().localPosition;
                    selection += 1;
                    selection %= 8;
                    ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x + (selection % 4) * 150, tmp.y - (selection / 4) * 150, 0);
                }
            }

            if (InputManager.Pressed(0, 6) || InputManager.Pressed(1, 6))
            {
                timer =0.2f;
                //Durch Bestätigungs-Button ausführen
                //MainButtons(xy);
                if (Singleplayer.IsActive() == true)
                {
                    MainButtons(selection);
                }
                else if(selection < 3)
                {
                    Load(selection+1);
                }
            }

            if (InputManager.Pressed(0, 5) || InputManager.Pressed(1, 5))
            {
                timer =0.2f;
                //Durch Return-Button zurückkehren
                //MainButtons(xy);
                if (!Singleplayer.IsActive() == true)
                {
                    MainButtons(5);
                }
            }
        }
    }
    public void MainButtons(int ButtonID)
    {
        //MainButtons deaktivieren + Return aktivieren
        if (ButtonID != 5 && ButtonID != 0)
        {
            //Rausgenommen: Multiplayer.gameObject.SetActive(false);
            Singleplayer.gameObject.SetActive(false);
            //Help.gameObject.SetActive(false);
            Quit.gameObject.SetActive(false);
            //Options.gameObject.SetActive(false);
            Return.gameObject.SetActive(true);
        }
        //Controllersteuerung Seitenstartpunkt setzen (Play/Zurück)
        
        switch (ButtonID)//Entsprechende Buttons/Bilder freischalten
        {
            //case 1://Help
                //Text aktivieren!!!!!
                //Schaltflächen aktivieren
                //Zurück.gameObject.SetActive(true);
                //Weiter.gameObject.SetActive(true);
                //Info aktivieren
                //Info.gameObject.SetActive(true);
                //Infotext.gameObject.SetActive(true);
                //Infopage = 0;
                //break;
            //case 2://Options
                //Optionenbuttons aktivieren!!!!!
                //ShipControl.gameObject.SetActive(true);
                //CanonControl.gameObject.SetActive(true);
                //break;
            //case 3://Singleplayer (rausgenommen
                //Image Player1 aktivieren und richtig positionieren (+Pla2)
                //Player1.GetComponent<RectTransform>().localPosition = new Vector3(-75, 100, 0);
                //Player1.gameObject.SetActive(true);
                //Player2.GetComponent<RectTransform>().localPosition = new Vector3(75, -50, 0);
                //Player2.gameObject.SetActive(true);
                //start.gameObject.SetActive(true);
                //break;
            case 4://Levelauswahl
                //Player1 auf Position setzen
                //Player1.GetComponent<RectTransform>().localPosition = new Vector3(-75, 75, 0);
                selection = 0;
                //Images aktivieren
                Player1.gameObject.SetActive(true);
                Player2.gameObject.SetActive(true);
                Player3.gameObject.SetActive(true);
                Player4.gameObject.SetActive(true);
                Player5.gameObject.SetActive(true);
                Player6.gameObject.SetActive(true);
                Player7.gameObject.SetActive(true);
                Player8.gameObject.SetActive(true);
                Title.gameObject.SetActive(false);
                //start.gameObject.SetActive(true);
                //Marker setzen
                Vector2 tmp = Player1.GetComponent<RectTransform>().localPosition;
                ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp.x, tmp.y, 0);
                ConCursor.GetComponent<RectTransform>().sizeDelta = new Vector2(105, 105);
                break;
            case 5://Return
                //Zu Main wechseln
                selection = 3;
                //Rausgenommen: Multiplayer.gameObject.SetActive(true);
                Singleplayer.gameObject.SetActive(true);
                //Help.gameObject.SetActive(true);
                Quit.gameObject.SetActive(true);
                //Options.gameObject.SetActive(true);
                
                //Andere Buttons deaktivieren
                Return.gameObject.SetActive(false);
                //Zurück.gameObject.SetActive(false);
                //Weiter.gameObject.SetActive(false);
                //start.gameObject.SetActive(false);
                //Images deaktivieren
                Player1.gameObject.SetActive(false);
                Player2.gameObject.SetActive(false);
                Player3.gameObject.SetActive(false);
                Player4.gameObject.SetActive(false);
                Player5.gameObject.SetActive(false);
                Player6.gameObject.SetActive(false);
                Player7.gameObject.SetActive(false);
                Player8.gameObject.SetActive(false);
                Title.gameObject.SetActive(true);
                //Info.gameObject.SetActive(false);
                //Text deaktivieren
                //Infotext.gameObject.SetActive(false);
                //Toggles deaktivieren  //ShipControl.gameObject.SetActive(false);  //CanonControl.gameObject.SetActive(false);

                //Marker setzen
                Vector2 tmp1 = Singleplayer.GetComponent<RectTransform>().localPosition;
                ConCursor.GetComponent<RectTransform>().localPosition = new Vector3(tmp1.x, tmp1.y, 0);
                ConCursor.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 34);
                selection = 4;
                break;
            //case 6:     //Zurück    //Seitenumschalten rückwärts    Infopage--;     break;
            //case 7:   //weiter   //Seitenumschalten vorwärts      Infopage++;     break;
            //case 8:   //Start    //Wechsel zu Scene "Playing"    Application.LoadLevel(1);   break;
            default://Quit
                Application.Quit();
                break;
        }
    }

    void OnApplicationQuit()
    {
        
            InputManager.outLED(0);
         InputManager.outLED(1);
        Debug.Log("QUIT");
    }
    public void Load(int Level)
    {
        GameData.setLevel(Level);
        SceneManager.LoadScene("Lvl"+Level);
    }
}
