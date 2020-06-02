using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDefeat : MonoBehaviour
{
    public Text healthyScore;
    public Transform playerBase;
    public string heaaalth;

    void Start()
    {
        healthyScore.text = "";
        playerBase = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerBase.childCount == 0)
        {
            GameOver.isPlayerDead = true;
        }
     heaaalth = playerBase.childCount.ToString();
        healthyScore.text = heaaalth;
    }
}