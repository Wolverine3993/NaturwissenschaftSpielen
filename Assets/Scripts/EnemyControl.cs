using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] Rigidbody2D enemyRigidbody;
    [SerializeField] BoxCollider2D boxCollideeer;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Animator anim;
    [SerializeField] float MovementSpeed;
    [SerializeField] int health;
    int direction = 1;
    float timer = 0.1f;
    float _timer;
    private void Update()
    {
        if (!OnFloor() && _timer <= 0)
        {
            direction = direction * -1;
            _timer = timer;
        }
        else if (timer > 0)
            _timer -= Time.deltaTime;
        enemy.position = new Vector2(enemy.position.x + Time.deltaTime * MovementSpeed * direction, enemy.position.y);
        if(direction == -1)
            enemy.localScale = new Vector2(Mathf.Abs(enemy.localScale.x) * -1, enemy.localScale.y);
        else
            enemy.localScale = new Vector2(Mathf.Abs(enemy.localScale.x), enemy.localScale.y);
    }

    private bool OnFloor()
    {
        RaycastHit2D onEdgeOne = Physics2D.Raycast(new Vector2(boxCollideeer.bounds.center.x - boxCollideeer.bounds.size.x/2, boxCollideeer.bounds.center.y - boxCollideeer.bounds.size.y / 2), Vector2.down, 0.2f, groundLayer);
        RaycastHit2D onEdgeTwo = Physics2D.Raycast(new Vector2(boxCollideeer.bounds.center.x + boxCollideeer.bounds.size.x / 2, boxCollideeer.bounds.center.y - boxCollideeer.bounds.size.y / 2), Vector2.down, 0.2f, groundLayer);
        if (onEdgeOne == false)
            return onEdgeOne;
        return onEdgeTwo;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
            if (health <= 0)
                gameObject.SetActive(false);
        }        
    }
}
