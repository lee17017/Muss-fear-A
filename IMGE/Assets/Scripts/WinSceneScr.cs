using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSceneScr : MonoBehaviour {
    private int CamAngle = 60;
    private int delta=2;
    private float delay = 2;
    public Text Win;
    public Image Info;
    public Button Next;
    public Button Menu;
    public Image Sel;
    public Image Instr;
    public Image Star1;
    public Image Star2;
    public Image Star3;
    public Image Star4;
    private int rotation = 0;
    private bool next = true;
	// Use this for initialization
	void Start () {
        InputManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        if (CamAngle < 178)
        {
                CamAngle += delta;
                Camera.main.transform.GetComponent<Camera>().fieldOfView = CamAngle;
                if (CamAngle > 10)
                {
                    delta = 16;
                }
                
        }
        else
        {
            gameObject.transform.Rotate(Vector3.up, 0.5f);
            gameObject.transform.Rotate(Vector3.right, 0.5f);
            if (rotation < 91) {
                Win.rectTransform.rotation = Quaternion.Euler(90-rotation, 0, 0);
                Win.gameObject.SetActive(true);
                rotation += 4;
            }
            else if (rotation < 182)
            {
                Info.rectTransform.rotation = Quaternion.Euler(90 - (rotation-91), 0, 0);
                Info.gameObject.SetActive(true);
                Star1.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 91), 0, 0);
                Star1.gameObject.SetActive(true);
                rotation+=4;
            }
            else if (rotation < 273)
            {
                Next.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 182), 0, 0);
                Next.gameObject.SetActive(true);
                Sel.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 182), 0, 0);
                Sel.gameObject.SetActive(true); 
                Star2.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 90 - (rotation - 182), 0);
                Star2.gameObject.SetActive(true);
                rotation += 8;
            }
            else if (rotation < 364)
            {
                Menu.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 273), 0, 0);
                Menu.gameObject.SetActive(true);
                Star3.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 90 - (rotation - 273), 0);
                Star3.gameObject.SetActive(true);
                rotation += 8;
            }
            else if (rotation < 455)
            {
                Instr.rectTransform.rotation = Quaternion.Euler(90 - (rotation - 364), 0, 0);
                Instr.gameObject.SetActive(true);
                Star4.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(0, 90 - (rotation - 364), 0);
                Star4.gameObject.SetActive(true);
                rotation += 8;
            }
        }
        if (CamAngle > 178)
        {
            Camera.main.transform.GetComponent<Camera>().fieldOfView = 178;
        }
        //Input von Controller einstellen
        checkConInputs();//Das immer ganz am Ende lassen oder in lateUpdate
	}

    private void checkConInputs()
    {
        delay -= Time.deltaTime;
        
        if ((delay < 0) && (InputManager.Pressed(0, 6) || InputManager.Pressed(1, 6)))//Apply
        {
            if (next) {
                nextLvlLoader();
            }
            else
            {
                goToMenu();
            }
        }
        if ((delay < 0) && (InputManager.Pressed(0, 3) || InputManager.Pressed(1, 3)))//Go Left
        {
            Sel.GetComponent<RectTransform>().localPosition = new Vector3(-125, -130, 0);
            next = true;
        }
        if ((delay < 0) && (InputManager.Pressed(0, 4) || InputManager.Pressed(1, 4)))//Go Right
        {
            Sel.GetComponent<RectTransform>().localPosition = new Vector3(125, -130, 0);
            next = false;
        }
        if ((delay < 0) && (InputManager.Pressed(0, 5) || InputManager.Pressed(1, 5)))//Return
        {
            goToMenu();
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void nextLvlLoader()
    {
        int next = GameData.getLast()+1;
        if (next >= GameData.DLC_Limit)
        {
            goToMenu();
        }
        GameData.setLevel(next);
        SceneManager.LoadScene("Lvl" + next);
    }
}
