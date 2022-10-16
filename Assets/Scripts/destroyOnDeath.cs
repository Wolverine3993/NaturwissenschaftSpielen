using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Button").GetComponent<NextScene>().smene = GameObject.Find("Controller").GetComponent<Quit>().scene;
        if (GameObject.Find("Capsule") != null)
            Destroy(GameObject.Find("Capsule"));
        if (GameObject.Find("CutsceneController") != null)
            Destroy(GameObject.Find("CutsceneController"));
        if (GameObject.Find("booletControl") != null)
            Destroy(GameObject.Find("booletControl"));
    }
}
