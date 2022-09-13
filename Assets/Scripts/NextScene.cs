using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextScene : MonoBehaviour
{
    public int smene = 0;
    public void LoadScene()
    {
        smene = 1;
        SceneManager.LoadScene(sceneName: "SampleScene");
    }
}
