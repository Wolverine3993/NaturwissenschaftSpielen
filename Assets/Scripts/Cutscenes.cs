using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    [SerializeField] GameObject cinematicBars;
    [SerializeField] GameObject Booss1;
    [SerializeField] GameObject BossFake;
    [SerializeField] float movementSpeed;
    bool boss1Cutscene;
    float timer1 = 3f;
    int pointIn = 0;
    private void Start()
    {
        boss1Cutscene = false;
        GoToPlayer();
    }
    private void Update()
    {
        if (boss1Cutscene)
            Boss1();
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
    public void Boss1()
    {
        if (pointIn == 0)
        {
            GoToPlayer();
            pointIn = 1;
        }
        boss1Cutscene = true;
        cinematicBars.SetActive(true);
        if (timer1 <= 0 && pointIn == 1)
        {
            transform.position = new Vector2(transform.position.x + -((transform.position.x - 0) * Time.deltaTime * movementSpeed), transform.position.y + -((transform.position.x - 46) * Time.deltaTime * movementSpeed));
            if (transform.position.x >= 0 && transform.position.y >= 46)
            {
                pointIn = 2;
                timer1 = 2f;
            }
           
        }else if (timer1 <= 0 && pointIn == 2)
        {
            BossFake.transform.position = transform.position;
            BossFake.SetActive(true);
            pointIn = 3;
            timer1 = 3f;
        }else if(timer1 <= 0 && pointIn == 3)
        {
            Booss1.transform.position = transform.position;
            Booss1.SetActive(true);
            BossFake.SetActive(false);
            boss1Cutscene = false;
        }
        timer1 -= Time.deltaTime;
    }

}
