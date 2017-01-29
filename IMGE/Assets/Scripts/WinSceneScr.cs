using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WinSceneScr : MonoBehaviour {
    private int CamAngle = 60;
    private int delta=2;
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
        }
        if (CamAngle > 178)
        {
            Camera.main.transform.GetComponent<Camera>().fieldOfView = 178;
        }
	}
}
