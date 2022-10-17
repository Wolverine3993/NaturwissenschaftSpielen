using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer[] hearts;
    [SerializeField] Sprite[] heartSprites;
    int health;
    private void Start()
    {
    }
    void Update()
    {
        health = player.GetComponent<PlayerHurt>().health;
        if (health == 3)
        {
            hearts[1].sprite = heartSprites[0];
            hearts[2].sprite = heartSprites[0];
        }
        else if (health == 2)
        {
            hearts[2].sprite = heartSprites[1];
            hearts[1].sprite = heartSprites[0];
        }
        else
        {
            hearts[1].sprite = heartSprites[1];
            hearts[2].sprite = heartSprites[1];
        }
    }
}
