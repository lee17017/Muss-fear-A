using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLvlLoader : MonoBehaviour {

    public GameObject player;
    public int maxCP;
    public string nextLvlName;
    public float delay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<PlayerBehaviour>().checkPointNr >= maxCP)
            StartCoroutine("LoadScene");
       
	}
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLvlName);
    }
}
