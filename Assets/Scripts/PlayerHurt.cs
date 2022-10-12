using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] float icooldown;
    [SerializeField] int MaxHealth;
    [SerializeField] float spriteTimer;
    [SerializeField] Rigidbody2D boby;
    [SerializeField] SpriteRenderer sprite;
    float _spriteTimer;
    public int health;
    float _icooldown;

    private void Start()
    {
        health = MaxHealth;
    }
    private void Update()
    {
        if (_icooldown > 0)
            _icooldown -= Time.deltaTime;
        if (_spriteTimer > 0 && _icooldown > 0)
            _spriteTimer -= Time.deltaTime;
        if (_icooldown > 0 && _spriteTimer <= 0)
        {
            sprite.enabled = !sprite.enabled;
            _spriteTimer = spriteTimer;
        }
        else if(_icooldown <= 0)
        {
            sprite.enabled = true;
        }
        if(transform.position.y <= -18.9)
        {
            health--;
            if (health > 0)
            {
                transform.position = new Vector2(-0.63f, 1.8f);
                boby.velocity = new Vector2(0f, 0f);
            }
            else
            {
                Dead();
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && _icooldown <= 0)
        {
            health--;
            if (health <= 0)
                Dead();
            _icooldown = icooldown;
            _spriteTimer = spriteTimer;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart" && health < MaxHealth)
        {
            collision.gameObject.SetActive(false);
            health++;
        }else if(collision.gameObject.tag == "Fire" && _icooldown <= 0)
        {
            health--;
            if (health <= 0)
                Dead();
            _icooldown = icooldown;
            _spriteTimer = spriteTimer;
        }
    }

    private void Dead()
    {
        SceneManager.LoadScene("Dead");
    }
}
