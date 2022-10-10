using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] fires;
    float timer;
    private void Start()
    {
        timer = 0.1f;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = fires.Length; i > 0; i--)
            {
                if (fires[i].activeInHierarchy == false)
                {
                    fires[i].transform.position = transform.position;
                    fires[i].SetActive(true);
                }
            }
            timer = 0.1f;
        }
    }
}
