using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] Transform enemy;
    float timer;
    [SerializeField] float minTimer;
    [SerializeField] float maxTimer;
    int direction = 1;
    [SerializeField] int movementSpeed;
    [SerializeField] float cooldown;
    bool turned = false;
    [SerializeField] LayerMask groundlayer;
    [SerializeField] BoxCollider2D boxcollider;
    float _cooldown;
    void Start()
    {
        timer = Random.Range(minTimer, maxTimer);
        _cooldown = cooldown;
    }

    void Update()
    {
        
        if(timer <= 0)
        {
            if (_cooldown >= 0)
                _cooldown -= Time.deltaTime;
            else if (OnFloor() == false)
            {
                transform.position = new Vector2(enemy.position.x + Time.deltaTime * -direction * movementSpeed, enemy.position.y);
            }
            else
            {
                if (turned == false)
                    direction = direction * -1;
                else
                    turned = false;
                _cooldown = cooldown;
                timer = Random.Range(minTimer, maxTimer);
            }
        }
        else
        {
            if (!OnFloor() && turned == false)
            {
                direction = direction * -1;
                turned = true;
            }
            enemy.position = new Vector2(enemy.position.x + Time.deltaTime * direction * movementSpeed, enemy.position.y);
            timer -= Time.deltaTime;
        }
        if (direction == -1)
            enemy.localScale = new Vector3(Mathf.Abs(enemy.localScale.x) * -1, enemy.localScale.y, enemy.localScale.z);
        else
            enemy.localScale = new Vector3(Mathf.Abs(enemy.localScale.x), enemy.localScale.y, enemy.localScale.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            gameObject.SetActive(false);
    }

    private bool OnFloor()
    {
        RaycastHit2D onEdgeOne = Physics2D.Raycast(new Vector2(boxcollider.bounds.center.x + boxcollider.bounds.center.x/2, boxcollider.bounds.min.y), Vector2.down, 0.1f);
        RaycastHit2D onEdgeTwo = Physics2D.Raycast(new Vector2(boxcollider.bounds.center.x - boxcollider.bounds.center.x/2, boxcollider.bounds.min.y), Vector2.down, 0.1f);
        if (onEdgeOne == false)
        {
            return onEdgeOne != false;
        }
        return onEdgeTwo != false;
    }
}
