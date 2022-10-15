using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolet : MonoBehaviour

{
    [SerializeField] private float Timer;
    [SerializeField] Vector3 mousepos;
    [SerializeField] GameObject bulletPoint;
    Ignore mtmtmtmtmmtm;
    Rigidbody2D body;
    CircleCollider2D bulletObject;
    bulletControl bulletControl;
    public float yVal;
    private float timer;
    public float direction;
    private bool shot = false;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();



    }
    private void Update()
    {
        if (!shot)
            Shoot();
        if (timer <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        timer = 5f;
        mousepos = getMousePos(bulletPoint.transform.position);
        yVal = Mathf.Atan2(mousepos.y - bulletPoint.transform.position.y, mousepos.x - bulletPoint.transform.position.x);
        GameObject bulletpoint = GameObject.Find("shootypoint");
        direction = Mathf.Sign(GameObject.Find("Capsule").transform.localScale.x);

        GameObject bulletControlG = GameObject.Find("booletControl");
        bulletControl = bulletControlG.GetComponent<bulletControl>();
        float booletSpeed = bulletControl.booletSpeed;
        
        mtmtmtmtmmtm = bulletPoint.GetComponent<Ignore>();
        transform.position = mtmtmtmtmmtm.GetPos();
        Vector2 playerPos = GameObject.Find("Capsule").GetComponent<Rigidbody2D>().velocity;
        if (yVal <= 2.3f && yVal >= 1.4f && direction == 1 || yVal >= -2.3f && yVal <= -1.4f && direction == 1)
            body.velocity = new Vector2(booletSpeed * -direction, booletSpeed * Mathf.Sign(yVal));
        else if (yVal >= 0.8f && yVal < 1.8f && direction == -1 || yVal <= -0.8f && yVal > -1.8f && direction == -1)
            body.velocity = new Vector2(booletSpeed * -direction, booletSpeed * Mathf.Sign(yVal));
        else
            body.velocity = new Vector2(booletSpeed * -direction, 0f);
        shot = true;
    }

    private Vector3 getMousePos(Vector3 shootpos)
    {
        Vector3 mospos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mospos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "player")
            GameObject.Destroy(gameObject);
    }
}