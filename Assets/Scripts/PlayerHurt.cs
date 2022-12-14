using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] float icooldown;
    [SerializeField] int MaxHealth;
    [SerializeField] SpriteRenderer armSprite;
    [SerializeField] float spriteTimer;
    [SerializeField] Rigidbody2D boby;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] AudioSource hit;
    CapsuleCollider2D boxcollider;
    bool hurt = false;
    Collider2D sretfghubijkkijuhn;
    float _spriteTimer;
    public int health;
    float _icooldown;
    private void Awake()
    {
        boxcollider = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        health = 3;
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
            armSprite.enabled = !armSprite.enabled;
            _spriteTimer = spriteTimer;
        }
        else if(_icooldown <= 0 && hurt)
        {
            sprite.enabled = true;
            armSprite.enabled = true;
            if(sretfghubijkkijuhn != null)
                Physics2D.IgnoreCollision(boxcollider, sretfghubijkkijuhn, false);
            hurt = false;
        }
        if(transform.position.y <= -18.9)
        {
            health--;
            if (health > 0)
            {
                Vector2 pos = GetComponent<PlayerMovement>().playerpos;
                transform.position = new Vector2(Mathf.Sign(pos.x) * Mathf.Abs(pos.x - 0.5f), pos.y + 0.5f);
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
            hurt = true;
            Physics2D.IgnoreCollision(boxcollider, collision.gameObject.GetComponent<Collider2D>());
            sretfghubijkkijuhn = collision.gameObject.GetComponent<Collider2D>();
            hit.Play();
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
            hit.Play();
        }
    }

    private void Dead()
    {
        SceneManager.LoadScene("Dead");
    }
}
