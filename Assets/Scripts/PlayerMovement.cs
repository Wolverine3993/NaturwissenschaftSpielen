using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D boby;
    [SerializeField] public float direction;
    [SerializeField] private float jumpHeight;
    [SerializeField] Animator anim;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] GameObject cutscenez;
    [SerializeField] private float wallSlide;
    private Collider2D boxColider;
    [SerializeField] private float speed = 1f;
    private void Awake()
    {
        boxColider = GetComponent<Collider2D>();
        
    }
    void Update()
    {
        bool inCutscene = cutscenez.GetComponent<Cutscenes>().boss1Cutscene;
        float input = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        if (inputy > 0 && TouchingGround() && !TouchingWallRight() && !inCutscene)
        {
            Jump();
        }
        if (!inCutscene)
        {
            if (input > 0)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, 1f);
            if (input < 0)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1f);

            if (input > 0 || input < 0)
                anim.SetBool("walking", true);
            else
                anim.SetBool("walking", false);


            direction = input;

            boby.velocity = new Vector2(input * speed, boby.velocity.y);
        }
        else
            anim.SetBool("walking", false);
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
        this.GetComponent<AudioSource>().Play();
        
    }
    private bool TouchingGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(boxColider.bounds.center.x, boxColider.bounds.center.y - boxColider.bounds.size.y/2), new Vector2(boxColider.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, groundLayer);
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
