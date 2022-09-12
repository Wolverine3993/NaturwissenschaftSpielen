using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    [SerializeField] public float booletSpeed;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private int cooldown;
    private float timer = 0;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timer <= 0)
        {
            Shoot();
            timer = 0.5f;
        }
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        for(int i = bullets.Length-1; i > -1; i--)
        {
            if (bullets[i].activeInHierarchy == false)
            {
                bullets[i].SetActive(true);
                return;
            }
        }
    }
}
