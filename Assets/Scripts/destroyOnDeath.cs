using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Button").GetComponent<NextScene>().smene = GameObject.Find("Controller").GetComponent<Quit>().scene;
        Destroy(GameObject.Find("CutsceneController"));
        GameObject.Find("Capsule").transform.position = new Vector2(100, 100);
    }
}
