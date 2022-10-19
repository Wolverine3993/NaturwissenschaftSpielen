using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLevelTwoLoad : MonoBehaviour
{
    
    private void Start()
    {
        GameObject.Find("Capsule").transform.position = new Vector2(0.91f, 0); 
        GameObject.Find("Controller").GetComponent<Quit>().scene = 2;
        GameObject.Find("CutsceneController").GetComponent<Cutscene>().boss1Cutscene = true;
    }
}
