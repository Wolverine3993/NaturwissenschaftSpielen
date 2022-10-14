using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTriggers : MonoBehaviour
{
    [SerializeField] GameObject cutsceneController;
    [SerializeField] GameObject boss1Floor;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss1")
        {
            collision.gameObject.SetActive(false);
            GameObject.Find("Capsule").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = new Vector2(transform.position.x, 42.39f);

            Boss1();
        }
    }
    
    private void Boss1()
    {
        boss1Floor.SetActive(true);
        GameObject.Find("Boss1").SetActive(false);
        cutsceneController.GetComponent<Cutscenes>().Boss1();
    }
}
