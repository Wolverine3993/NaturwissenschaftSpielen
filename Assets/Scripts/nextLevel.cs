using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Capsule")
        {
            GameObject.Find("Controller").GetComponent<Quit>().scene = 2; 
            SceneManager.LoadScene(sceneName: "Level2");
            GameObject.Find("Capsule").GetComponent<PlayerHurt>().health = 3;
        }
    }
}
