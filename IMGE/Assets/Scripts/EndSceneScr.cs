using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneScr : MonoBehaviour {

    private float delay = 0.5f;
	// Use this for initialization
	void Start () {
        InputManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        for (int i = 1; i < 7; i++)
        {
            if ((delay < 0) && (InputManager.Pressed(0, i) || InputManager.Pressed(1, i)))
            {
                goToMain();
                return;
            }

        }
	}
    public void goToMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
