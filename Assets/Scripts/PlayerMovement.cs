using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D boby;
    [SerializeField] public float direction;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float wallSlide;
    private BoxCollider2D boxColider;
    [SerializeField] private float speed = 1f;
    private void Awake()
    {
        boby = GetComponent<Rigidbody2D>();
        boxColider = GetComponent<BoxCollider2D>();
        
    }
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        if (inputy > 0 && TouchingGround() && !TouchingWallRight())
        {
            Jump();
        }
        if (input > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1f);
        if (input < 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, 1f);
        
        direction = input;
        
        ///move left and right
        boby.velocity = new Vector2(input * speed, boby.velocity.y);
        ///set rotation
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        ///jump
        
        Sprint();

        ///wall no stick
        if (TouchingWallRight() && boby.velocity.y <= 0)
            boby.velocity = new Vector2(boby.velocity.x, -wallSlide);
    }

    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 7f;
        else
            speed = 5f;
    }
    public void Jump()
    {
        
        boby.velocity = new Vector2(boby.velocity.x, jumpHeight);
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Enemy")
            Dead();

    }

    public void Dead()
    {
        transform.position = new Vector2(-0.63f, 1.8f);
        boby.velocity = new Vector2(0f, 0f);
    }
    private bool TouchingGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit != false;
    }
    private bool TouchingWallRight()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, new Vector3(boxColider.bounds.size.x, boxColider.bounds.size.y - 0.2f, boxColider.bounds.size.z), 0f, Vector2.right, 0.1f, groundLayer);
        RaycastHit2D rarycastHit = Physics2D.BoxCast(boxColider.bounds.center, new Vector3(boxColider.bounds.size.x, boxColider.bounds.size.y - 0.2f, boxColider.bounds.size.z), 0f, Vector2.left, 0.1f, groundLayer);
        if (raycastHit != false)
            return raycastHit != false;
        return rarycastHit != false;
    }
    
}
