using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] GameObject cinematicBars;
    [SerializeField] GameObject Booss2Fake;
    public int cutsceneNumber = 1;
    public bool boss1Cutscene;
    float timer1 = 3f;
    int pointIn = 0;
    private void Update()
    {
        if (boss1Cutscene)
            Boss2();
        else
        {
            transform.position = GameObject.Find("Capsule").transform.position;
            if (cinematicBars.activeInHierarchy)
                cinematicBars.SetActive(false);
        }
    }
    public void GoToPlayer()
    {
        transform.position = GameObject.Find("Capsule").transform.position;
    }
    public void Boss2()
    {
        if (pointIn == 0)
        {
            GoToPlayer();
            pointIn = 1;
            timer1 = 3.5f;
        }
        GameObject.Find("Capsule").GetComponent<PlayerMovement>().inCutscene = true;
        cinematicBars.SetActive(true);
        if (pointIn == 1)
        {

            transform.position = new Vector2((transform.position.x + (Booss2Fake.transform.position.x - transform.position.x) / 200), (transform.position.y + (Booss2Fake.transform.position.y - transform.position.y) / 200));
            if (timer1 <= 0)
            {
                pointIn = 2;
            }

        }
        else if (timer1 <= 0 && pointIn == 2)
        {

            Booss2Fake.GetComponent<boss2>().canSpawn = true;
            boss1Cutscene = false;
            GameObject.Find("Capsule").GetComponent<PlayerMovement>().inCutscene = false;
            Camera.main.orthographicSize = 7f;
            pointIn = 0;
        }
        timer1 -= Time.deltaTime;
    }

}
