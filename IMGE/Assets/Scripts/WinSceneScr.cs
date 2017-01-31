using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSceneScr : MonoBehaviour {
    private int CamAngle = 60;
    private int delta=2;
    public Text Win;
    public Image Info;
    public Button Next;
    public Button Menu;
    public Image Sel;
    public Image Instr;
    private int rotation = 0;
	// Use this for initialization
	void Start () {
        
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
                rotation += 2;
            }
            else if (rotation < 182)
            {
                Info.rectTransform.rotation = Quaternion.Euler(90 - (rotation-91), 0, 0);
                Info.gameObject.SetActive(true);
                
                rotation+=4;
            }
            else if (rotation < 273)
            {
                Next.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 182), 0, 0);
                Next.gameObject.SetActive(true);
                Sel.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 182), 0, 0);
                Sel.gameObject.SetActive(true);
                Instr.rectTransform.rotation = Quaternion.Euler(90 - (rotation - 182), 0, 0);
                Instr.gameObject.SetActive(true);
                rotation += 4;
            }
            else if (rotation < 364)
            {
                Menu.GetComponent<Image>().rectTransform.rotation = Quaternion.Euler(90 - (rotation - 273), 0, 0);
                Menu.gameObject.SetActive(true);
                rotation += 4;
            }
        }
        if (CamAngle > 178)
        {
            Camera.main.transform.GetComponent<Camera>().fieldOfView = 178;
        }
        //Input von Controller einstellen

	}

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void nextLvlLoader()
    {
        //Load next Scene
    }
}
