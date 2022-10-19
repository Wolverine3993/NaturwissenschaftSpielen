using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        Destroy(GameObject.Find("Capsule"));
        Destroy(GameObject.Find("booletControl"));
        Destroy(GameObject.Find("Controller"));
    }
}
