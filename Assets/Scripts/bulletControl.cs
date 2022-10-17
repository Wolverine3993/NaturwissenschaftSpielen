using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    [SerializeField] public float booletSpeed;
    [SerializeField] private GameObject bullets;
    [SerializeField] public float cooldown;
    Transform shootyPoint;
    private float timer = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && timer <= 0)
        {
            Shoot();
            timer = cooldown;
        }
        timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        shootyPoint = GameObject.Find("shootypoint").transform;
        GameObject bullet = GameObject.Instantiate(bullets, shootyPoint.position, transform.rotation, transform);
        bullet.SetActive(true);
    }
}
