using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyAtomHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject explode;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            health--;
        if (health <= 0)
        {
            GameObject clone = GameObject.Instantiate(explode, transform.position, transform.rotation);
            Destroy(clone, 0.4f);
            gameObject.SetActive(false);
        }
            
    }
}
