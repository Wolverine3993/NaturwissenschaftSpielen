using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class tree : MonoBehaviour
{
    float timer = 0.2f;
    int dir = 1;
    private void Update()
    {
        if(dir == 1)
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f * Time.deltaTime);
        if(dir == -1) 
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f *Time.deltaTime);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            dir = dir * -1;
            timer = 0.2f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Capsule")
            SceneManager.LoadScene(sceneName: "EndScreen");
    }
}
