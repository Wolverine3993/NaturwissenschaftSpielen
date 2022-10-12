using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTriggers : MonoBehaviour
{
    [SerializeField] LayerMask boss1;
    [SerializeField] LayerMask boss2;
    [SerializeField] GameObject boss1Enemies;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == boss1)
            Boss1();
    }
    
    private void Boss1()
    {
        GameObject.Find("boss1Floor").SetActive(true);
        boss1Enemies.SetActive(false);
    }
}
