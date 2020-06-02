using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
   
    
    public float health = 2;
    //public Text healthScore;

   
  public float playerScore = 2;

    private void Start()
    {
        //healthScore.text = "ok"+ health;
    }



    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
           

        
    }
}