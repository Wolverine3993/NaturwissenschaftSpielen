using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLevelTwoLoad : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("Capsule").transform.position = new Vector2(0, 0);
    }
}
