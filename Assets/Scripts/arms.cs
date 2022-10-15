using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arms : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite[] armSprites;
    Vector2 mousepos;
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouse = Mathf.Atan2(mousepos.y - bulletPoint.transform.position.y, mousepos.x - bulletPoint.transform.position.x);
        float playerD = Mathf.Sign(player.transform.localScale.x);
        if (mouse >= 0.8f && mouse < 1.8f && playerD == -1)
            sprite.sprite = armSprites[1];
        else if (mouse <= -0.8f && mouse > -1.8f && playerD == -1)
            sprite.sprite = armSprites[2];
        else if (mouse <= 2.3f && mouse >= 1.4f && playerD == 1)
            sprite.sprite = armSprites[1];
        else if (mouse >= -2.3f && mouse <= -1.4f && playerD == 1)
            sprite.sprite = armSprites[2];
        else if (Mathf.Abs(mouse) > 2.3f && playerD == 1)
            sprite.sprite = armSprites[0];
        else
            sprite.sprite = armSprites[0];
    }
}
