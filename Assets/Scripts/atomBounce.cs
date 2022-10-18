using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class atomBounce : MonoBehaviour
{
    [SerializeField] LayerMask groundlayer;
    [SerializeField] LayerMask atoms;
    [SerializeField] Collider2D boxcollider;
    Rigidbody2D body;
    float timerH = 0;
    float timerV = 0;
    float movementTimer = 0;
    float beginningTimer = 0.5f;
    bool moving = true;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        int bodyVX = Random.Range(-1, 2);
        int bodyVY = Random.Range(-1, 2);
        if (bodyVX == 0) bodyVX += 1;
        if (bodyVY == 0) bodyVY += 1;
        body.velocity = new Vector2(bodyVX * 5, bodyVY * 5);
        if (TouchingWallHorizontal())
        {
            if (transform.position.x > 9)
                transform.position = new Vector2(transform.position.x - 3, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x + 3, transform.position.y);
        }
        if (TouchingWallVertical())
        {
            if (transform.position.y > 30)
                transform.position = new Vector2(transform.position.x, transform.position.y - 3);
            else
                transform.position = new Vector2(transform.position.x, transform.position.y + 3);
        }
    }
    private void Update()
    {
        body = GetComponent<Rigidbody2D>();
        timerH -= Time.deltaTime;
        timerV -= Time.deltaTime;
        if (beginningTimer > 0)
            beginningTimer -= Time.deltaTime;
        if (moving)
        {
            if (timerH > 0)
                timerH -= Time.deltaTime;
            if (timerV > 0)
                timerV -= Time.deltaTime;
            if (TouchingWallHorizontal() && timerH <= 0 || TouchingAtomH() && timerH <= 0)
            {
                body.velocity = new Vector2(body.velocity.x * -1, body.velocity.y);
                timerH = 0.1f;
            }
            if (TouchingWallVertical() && timerV <= 0 || TouchingAtomV() && timerV <= 0)
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
                movementTimer = 0;
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
    private bool TouchingAtomH()
    {
        if (beginningTimer <= 0)
        {
            RaycastHit2D onWallRight = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x + boxcollider.bounds.size.x / 2 + 0.1f, boxcollider.bounds.center.y), new Vector2(0.1f, boxcollider.bounds.size.y), 0f, Vector2.right, 0.1f, atoms);
            RaycastHit2D onWallLeft = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x - boxcollider.bounds.size.x / 2 - 0.1f, boxcollider.bounds.center.y), new Vector2(0.1f, boxcollider.bounds.size.y), 0f, Vector2.left, 0.1f, atoms);
            if (onWallRight != false)
                return onWallRight != false;
            return onWallLeft != false;
        }
        else
            return false;
    }

    private bool TouchingAtomV()
    {
        if (beginningTimer <= 0)
        {
            RaycastHit2D onWallUp = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x, boxcollider.bounds.center.y + boxcollider.bounds.size.y / 2 + 0.1f), new Vector2(boxcollider.bounds.size.x, 0.1f), 0f, Vector2.up, 0.1f, atoms);
            RaycastHit2D onWallDown = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x, boxcollider.bounds.center.y - boxcollider.bounds.size.y / 2 - 0.1f), new Vector2(boxcollider.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, atoms);
            if (onWallUp != false)
                return onWallUp != false;
            return onWallDown != false;
        }
        else
            return false;
    }
}
