using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class babyAtomHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject explode;
    bool hurt;
    SpriteRenderer sprite;
    float hurtTimer;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (hurt)
        {
            sprite.enabled = false;
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0)
            {
                sprite.enabled = true;
                hurt = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hurt = true;
            hurtTimer = 0.1f;
            health--;
        }
        if (health <= 0)
        {
            hurt = false;
            GameObject clone = GameObject.Instantiate(explode, transform.position, transform.rotation);
            clone.SetActive(true);
            Destroy(clone, 0.4f);
            gameObject.SetActive(false);
        }
            
    }
}
