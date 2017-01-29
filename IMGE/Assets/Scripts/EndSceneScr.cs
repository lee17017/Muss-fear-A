using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (InputManager.Pressed(0, 5) || InputManager.Pressed(1, 5) || InputManager.Pressed(0, 6) || InputManager.Pressed(1, 6))
        {
            goToMain();
        }
	}
    public void goToMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
