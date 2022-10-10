using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;
    [SerializeField] float moveSpeed;
    bool up = true;
    void Update()
    {
        if (up == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            if (transform.position.y >= maxHeight)
                up = false;
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            if (transform.position.y <= minHeight)
                up = true;
        }
    }
}
