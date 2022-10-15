using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject[] atoms;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            if (health <= 0)
                Dead();
        }
    }
    private void Dead()
    {
        for(int i = atoms.Length - 1; i >= 0; i--)
            atoms[i].SetActive(true);
        gameObject.SetActive(false);
    }
}
