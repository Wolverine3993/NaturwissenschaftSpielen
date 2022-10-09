using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] float timer;
    float _timer;
    void Update()
    {
        if (_timer >= 0)
            transform.localScale = new Vector3(transform.localScale.x + 1 * Time.deltaTime, transform.localScale.y + 1 * Time.deltaTime, transform.localScale.z);
    }
}
