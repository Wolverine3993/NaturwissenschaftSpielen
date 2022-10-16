using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButForReal : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }
}
