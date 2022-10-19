using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class boss2 : MonoBehaviour
{
    [SerializeField] GameObject enemyweak;
    [SerializeField] GameObject enemystrong;
    [SerializeField] GameObject carbon;
    [SerializeField] float weakCooldown;
    [SerializeField] float strongCooldown;
    [SerializeField] float carbonCooldown;
    [SerializeField] int health;
    [SerializeField] public int carbonAtoms;
    [SerializeField] public int strongEnemies;
    [SerializeField] GameObject[] explodes;
    [SerializeField] GameObject finish;
    float deathTimer;
    int explose = 0;
    public bool canSpawn = false;
    float weakTimer;
    bool dead = false;
    float strongTimer;
    float carbonTimer;
    int phase = 1;
    private void Update()
    {
        if (health <= 23 && health > 15)
        {
            phase = 2;
            weakCooldown = 2.5f;
        }
        if (health <= 15 && health > 0)
        {
            phase = 3;
            strongCooldown = 3;
        }
        if (weakTimer > 0)
            weakTimer -= Time.deltaTime;
        if (strongTimer > 0)
            strongTimer -= Time.deltaTime;
        if (carbonTimer > 0)
            carbonTimer -= Time.deltaTime;
        if(!dead && canSpawn)
            Spawn();
        if (dead)
            Dead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" && canSpawn)
        {
            health--;
            Destroy(collision.gameObject);
        }
        if (health <= 0 && dead == false)
        {
            dead = true;
            deathTimer = 0.4f;
            Dead();
        }
    }

    private void Spawn()
    {
        if(phase == 1)
        {
            if (weakTimer <= 0) 
            {
                GameObject clone = GameObject.Instantiate(enemyweak, new Vector2(13.8f, -1.49f), transform.rotation);
                clone.SetActive(true);
                weakTimer = weakCooldown;
            }
        }
        else if (phase == 2)
        {
            if(weakTimer <= 0)
            {
                GameObject clone = GameObject.Instantiate(enemyweak, new Vector2(13.8f, -1.49f), transform.rotation);
                clone.SetActive(true);
                weakTimer = weakCooldown;
            }
            if(strongTimer <= 0 && strongEnemies < 4)
            {
                GameObject clone = GameObject.Instantiate(enemystrong, new Vector2(13.8f, -1.49f), transform.rotation);
                clone.SetActive(true);
                strongTimer = strongCooldown;
                strongEnemies++;
            }
        }else if(phase == 3)
        {
            if(strongTimer <= 0 && strongEnemies < 4)
            {
                GameObject clone = GameObject.Instantiate(enemystrong, new Vector2(13.8f, -1.49f), transform.rotation);
                clone.SetActive(true);
                strongTimer = strongCooldown;
                strongEnemies++;
            }
            if(carbonTimer <= 0 && carbonAtoms < 3)
            {
                GameObject clone = GameObject.Instantiate(carbon, new Vector2(18.43f, 3.97f), transform.rotation);
                clone.SetActive(true);
                carbonTimer = carbonCooldown;
                carbonAtoms++;
            }
        }
    }
    private void Dead()
    {
        if (explose == 0)
        {
            explodes[explose].SetActive(true);
            Destroy(explodes[explose], 0.4f);
            deathTimer = 0.3f;
            explose = 1;
        }
        else if(explose == 1 && deathTimer <= 0)
        {
            explodes[explose].SetActive(true);
            Destroy(explodes[explose], 0.4f);
            deathTimer = 0.4f;
            explose = 2;
        }
        else if(explose == 2 && deathTimer <= 0)
        {
            explodes[explose].SetActive(true);
            Destroy(explodes[explose], 0.4f);
            finish.SetActive(true);
            gameObject.SetActive(false);
        }
        deathTimer -= Time.deltaTime;
    }
}
