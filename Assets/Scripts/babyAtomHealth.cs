using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyAtomHealth : MonoBehaviour
{
    [SerializeField] int health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            health--;
        if (health <= 0)
            gameObject.SetActive(false);
            
    }
}
