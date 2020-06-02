using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    private Transform enemyHolder;
    public float speed;

    

    // Use this for initialization
    void Start()
    {
       
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform rightAnswer in enemyHolder)
        {
            if (rightAnswer.position.x < -3.5 || rightAnswer.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }
            if (rightAnswer.position.y <= -3)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }

        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        
    }
}