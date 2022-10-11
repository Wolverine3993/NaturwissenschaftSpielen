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
    private float timer;
    public bool shot = false;
    private float direction;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();



    }
    private void Update()
    {
        if (!shot)
            Shoot();
        if (timer <= 0 && shot)
        {
            shot = false;
            transform.position = new Vector2(1000f, 1000f);
            gameObject.SetActive(false);
        }
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        timer = 5f;
        mousepos = getMousePos(bulletPoint.transform.position);
        float yVal = Mathf.Atan2(mousepos.y - bulletPoint.transform.position.y, mousepos.x - bulletPoint.transform.position.x);
        GameObject bulletpoint = GameObject.Find("shootypoint");
        direction = Mathf.Sign(GameObject.Find("Capsule").transform.localScale.x);

        GameObject bulletControlG = GameObject.Find("booletControl");
        bulletControl = bulletControlG.GetComponent<bulletControl>();
        float booletSpeed = bulletControl.booletSpeed;
        
        mtmtmtmtmmtm = bulletPoint.GetComponent<Ignore>();
        transform.position = mtmtmtmtmmtm.GetPos();
        Debug.Log(yVal);
        if (Mathf.Abs(yVal) >= 0.8f && direction == 1)
            body.velocity = new Vector2(booletSpeed * direction, booletSpeed * Mathf.Sign(yVal));
        else if (Mathf.Abs(yVal) <= 2.3f && direction == -1)
            body.velocity = new Vector2(booletSpeed * direction, booletSpeed * Mathf.Sign(yVal));
        else
            body.velocity = new Vector2(booletSpeed * direction, 0f);
        shot = true;
    }

    private Vector3 getMousePos(Vector3 shootpos)
    {
        Vector3 mospos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mospos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shot)
        {
            shot = false;
            transform.position = new Vector2(1000f, 1000f);
            gameObject.SetActive(false);
        }
    }
}