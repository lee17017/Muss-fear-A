using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        //UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}