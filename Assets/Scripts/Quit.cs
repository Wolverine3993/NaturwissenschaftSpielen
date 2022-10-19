using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public int scene = 1;
    private void Start()
    {
        DontDestroyOnLoad(GameObject.Find("booletControl"));
        DontDestroyOnLoad(GameObject.Find("Capsule"));
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKey(KeyCode.L))
            SceneManager.LoadScene(sceneName: "Level2");
    }
}
