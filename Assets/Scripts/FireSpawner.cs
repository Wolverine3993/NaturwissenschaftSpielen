using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] GameObject fireEmpty;
    float timer;
    float lifeTimer;
    private void Start()
    {
        timer = 1f;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject clome = GameObject.Instantiate(fire, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), transform.rotation, fireEmpty.transform);
            clome.SetActive(true);
            Destroy(clome, 0.5f);
            timer = 0.1f;
        }
    }
}
