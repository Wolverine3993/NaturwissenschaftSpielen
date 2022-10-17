using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Vector2 playerpos;
    float jumpTimer;
    [SerializeField] private float speed = 1f;
    private void Awake()
    {
        boxColider = GetComponent<Collider2D>();
    }

    void Start()
    {
        boby.velocity = new Vector2(0f, -4f);
    }


    void Update()
    {
        bool inCutscene = cutscenez.GetComponent<Cutscenes>().boss1Cutscene;
        float input = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Space))
            inputy = 1;
        if (inputy > 0 && TouchingGroundReg() && !inCutscene && jumpTimer <= 0)
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
        if (TouchingGroundReg())
            playerpos = transform.position;
        ///wall no stick
        if (jumpTimer > 0)
            jumpTimer -= Time.deltaTime;
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
        jumpTimer = 0.1f;
        this.GetComponent<AudioSource>().Play();
        
    }
    private bool TouchingGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(boxColider.bounds.center.x, boxColider.bounds.center.y - boxColider.bounds.size.y/2), new Vector2(boxColider.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit != false;
    }

    private bool TouchingGroundReg()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(new Vector2(boxColider.bounds.center.x, boxColider.bounds.center.y - boxColider.bounds.size.y / 2), new Vector2(boxColider.bounds.size.x - 0.2f, 0.1f), 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit != false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "NextLevel")
            GameObject.Find("Controller").GetComponent<Quit>().scene = 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletP")
        {
            GameObject.Find("booletControl").GetComponent<bulletControl>().cooldown = 0.3f;
            Destroy(collision.gameObject, 0);
        }
    }

}
