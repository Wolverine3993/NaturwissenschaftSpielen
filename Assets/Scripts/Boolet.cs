using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour
    
{
    [SerializeField] private float Timer;
    Ignore mtmtmtmtmmtm;
    Rigidbody2D body;
    CircleCollider2D bulletObject;
    bulletControl bulletControl;
    private float timer;
    private bool shot = false;
    private float direction;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        
        
        
    }
    private void Update()
    {
        if(!shot)
            Shoot();
        if (timer <= 0 && shot)
        {
            shot = false;
            gameObject.SetActive(false);
        }
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
       
        timer = 5f;
        direction = Mathf.Sign(GameObject.Find("Capsule").transform.localScale.x);
        GameObject bulletControlG = GameObject.Find("booletControl");
        bulletControl = bulletControlG.GetComponent<bulletControl>();
        float booletSpeed = bulletControl.booletSpeed;
        GameObject bulletPoint = GameObject.Find("shootypoint");
        mtmtmtmtmmtm = bulletPoint.GetComponent<Ignore>();
        transform.position = mtmtmtmtmmtm.GetPos();
        body.velocity = new Vector2(direction * booletSpeed, 0f);
        
        shot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Capsule" && collision.gameObject.tag != "Bullet" && shot)
        {
            shot = false;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.name == "Capsule")
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collision.collider);
        }

    }
}
