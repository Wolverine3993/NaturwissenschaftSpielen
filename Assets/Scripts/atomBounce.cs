using System.Collections;
using System.Collections.Generic;
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
            transform.position = new Vector2(Mathf.Sign(transform.position.x) * (Mathf.Abs(transform.position.x) + 2), transform.position.y);
    }
    private void Update()
    {
        body = GetComponent<Rigidbody2D>();
        timerH -= Time.deltaTime;
        timerV -= Time.deltaTime;
        if (moving)
        {
            if (timerH > 0)
                timerH -= Time.deltaTime;
            if (timerV > 0)
                timerV -= Time.deltaTime;
            if (TouchingWallHorizontal() && timerH <= 0 || TouchingAtomH() && timerH <= 0)
            {
                body.velocity = new Vector2(body.velocity.x * -1, body.velocity.y);
                timerH = 0.05f;
            }
            if (TouchingWallVertical() && timerV <= 0 || TouchingAtomV() && timerV <= 0)
            {
                body.velocity = new Vector2(body.velocity.x, body.velocity.y * -1);
                timerV = 0.05f;
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
        RaycastHit2D onWallRight = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x + boxcollider.bounds.size.x / 2 + 0.1f, boxcollider.bounds.center.y), new Vector2(0.1f, boxcollider.bounds.size.y), 0f, Vector2.right, 0.1f, atoms);
        RaycastHit2D onWallLeft = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x - boxcollider.bounds.size.x / 2 - 0.1f, boxcollider.bounds.center.y), new Vector2(0.1f, boxcollider.bounds.size.y), 0f, Vector2.left, 0.1f, atoms);
        if (onWallRight != false)
            return onWallRight != false;
        return onWallLeft != false;
    }

    private bool TouchingAtomV()
    {
        RaycastHit2D onWallUp = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x, boxcollider.bounds.center.y + boxcollider.bounds.size.y / 2 + 0.1f), new Vector2(boxcollider.bounds.size.x, 0.1f), 0f, Vector2.up, 0.1f, atoms);
        RaycastHit2D onWallDown = Physics2D.BoxCast(new Vector2(boxcollider.bounds.center.x, boxcollider.bounds.center.y - boxcollider.bounds.size.y / 2 - 0.1f), new Vector2(boxcollider.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, atoms);
        if (onWallUp != false)
            return onWallUp != false;
        return onWallDown != false;
    }
}
