using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2Boss : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] BoxCollider2D boxcollider;
    [SerializeField] float movementSpeed;
    [SerializeField] LayerMask groundlayer;
    float movementTimer;
    bool moving;
    float timerH = 0;
    float timerV = 0;
    void Start()
    {
        int bodyVX = Random.Range(-1, 2);
        int bodyVY = Random.Range(-1, 2);
        if (bodyVX == 0) bodyVX += 1;
        if (bodyVY == 0) bodyVY += 1;
        body.velocity = new Vector2(bodyVX * movementSpeed, bodyVY * movementSpeed);
        moving = true;
        movementTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        bool dead = GetComponent<bossHealth>().dead;
        if (!dead)
        {
            if (moving)
            {
                if (timerH > 0)
                    timerH -= Time.deltaTime;
                if (timerV > 0)
                    timerV -= Time.deltaTime;
                if (TouchingWallHorizontal() && timerH <= 0)
                {
                    body.velocity = new Vector2(body.velocity.x * -1, body.velocity.y);
                    timerH = 0.1f;
                }
                if (TouchingWallVertical() && timerV <= 0)
                {
                    body.velocity = new Vector2(body.velocity.x, body.velocity.y * -1);
                    timerV = 0.1f;
                }
                movementTimer -= Time.deltaTime;
                if (movementTimer <= 0)
                {
                    moving = false;
                    movementTimer = 0;
                }
            }
            else
            {
                movementTimer -= Time.deltaTime;
                if (movementTimer <= 0)
                {
                    moving = true;
                    movementTimer = 5;
                }
            }
        }
    }
    private bool TouchingWallHorizontal()
    {
        RaycastHit2D onWallRight = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x + boxcollider.bounds.size.x / 2, boxcollider.bounds.center.y), new Vector2(0.1f, boxcollider.bounds.size.y), 0f, Vector2.right, 0.1f, groundlayer);
        RaycastHit2D onWallLeft = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x - boxcollider.bounds.size.x / 2, boxcollider.bounds.center.y), new Vector2(0.1f, boxcollider.bounds.size.y), 0f, Vector2.left, 0.1f, groundlayer);
        if (onWallRight != false)
            return onWallRight != false;
        return onWallLeft != false;
    }

    private bool TouchingWallVertical()
    {
        RaycastHit2D onWallUp = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x, boxcollider.bounds.center.y + boxcollider.bounds.size.y / 2), new Vector2(boxcollider.bounds.size.x, 0.1f), 0f, Vector2.up, 0.1f, groundlayer);
        RaycastHit2D onWallDown = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x, boxcollider.bounds.center.y - boxcollider.bounds.size.y / 2), new Vector2(boxcollider.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, groundlayer);
        if (onWallUp != false)
            return onWallUp != false;
        return onWallDown != false;
    }
}
