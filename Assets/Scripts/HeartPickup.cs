using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    [SerializeField] float timer;
    float _timer1;
    float _timer2;
    void Update()
    {
        if (_timer1 > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x + 1 * Time.deltaTime, transform.localScale.y + 1 * Time.deltaTime, transform.localScale.z);
            _timer1 -= Time.deltaTime;
        }
        else
        {
            if (_timer2 > 0)
                transform.localScale = new Vector3(transform.localScale.x - 1 * Time.deltaTime, transform.localScale.y - 1 * Time.deltaTime, transform.localScale.z);
            else
            {
                _timer1 = timer;
                _timer2 = timer;
            }
            _timer2 -= Time.deltaTime;

        }

    }
}
