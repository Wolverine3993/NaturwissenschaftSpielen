using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject[] atoms;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject nextLevel;
    SpriteRenderer sprite;
    BoxCollider2D boxcollider;
    int carbonDed = 0;
    bool hurt = false;
    public float hurtTimer;
    int oxy1Ded = 0;
    int oxy2Ded = 0;
    public bool dead = false;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(dead)
        {
            for(int i = atoms.Length - 1; i >= 0; i--)
            {
                if (atoms[i].gameObject.name == "Carbon" && atoms[i].activeInHierarchy == false)
                    carbonDed = 1;
                if (atoms[i].gameObject.name == "Oxygen" && atoms[i].activeInHierarchy == false)
                    oxy1Ded = 1;
                if (atoms[i].gameObject.name == "Oxygen (1)" && atoms[i].activeInHierarchy == false)
                    oxy2Ded = 1;
            }
            if (oxy1Ded == 1 && carbonDed == 1 && oxy2Ded == 1)
                NextLevel();
        }
        if (hurt)
        {
            sprite.enabled = false;
            hurtTimer -= Time.deltaTime;
            if(hurtTimer <= 0)
            {
                sprite.enabled = true;
                hurt = false;
            }
        }
               
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && !dead)
        {
            health--;
            hurt = true;
            hurtTimer = 0.1f;
            if (health <= 0)
            {
                hurt = false;
                Dead();
            }
        }
    }
    private void Dead()
    {
        for(int i = atoms.Length - 1; i >= 0; i--)
        {
            atoms[i].SetActive(true);
            if (atoms[i].gameObject.name == "Carbon")
                atoms[i].transform.position = transform.position;
            if (atoms[i].gameObject.name == "Oxygen")
                atoms[i].transform.position = new Vector2(transform.position.x + boxcollider.bounds.size.x / 2, transform.position.y - boxcollider.bounds.size.y / 2);
            if (atoms[i].gameObject.name == "Oxygen (1)")
                atoms[i].transform.position = new Vector2(transform.position.x - boxcollider.bounds.size.x / 2 - 3, transform.position.y - boxcollider.bounds.size.y / 2);
        }
        GameObject expl = GameObject.Instantiate(explosion, transform.position, transform.rotation);
        expl.transform.localScale = new Vector2(4, 4);
        expl.SetActive(true);
        Destroy(expl, 0.4f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CO2Boss>().enabled = false;
        dead = true;
    }

    private void NextLevel()
    {
        Camera.main.orthographicSize = 5;
        nextLevel.SetActive(true);
    }
}
