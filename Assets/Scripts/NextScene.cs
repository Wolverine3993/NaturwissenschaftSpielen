using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextScene : MonoBehaviour
{
    public int smene;
    private void Start()
    {
        smene = 1;
    }
    public void LoadScene()
    {
        if (GameObject.Find("Controller") != null)
            smene = GameObject.Find("Controller").GetComponent<Quit>().scene;
        if(smene == 1)
            SceneManager.LoadScene(sceneName: "SampleScene");
        if (smene == 2)
            SceneManager.LoadScene(sceneName: "Level2");
    }
}
