using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliding : MonoBehaviour
{
    //cached reference
    WCLevel level;
    GameStateWC stats;

    float x;
    float y;
    float z;
    Vector3 pos;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        x = Random.Range(2, 30);
        //y = 20;
        //y += Random.Range(20,200);
        y = Random.Range(20, 350);
        z = 0;
        pos = new Vector3(x, y, z);
        transform.position = pos;
        level = FindObjectOfType<WCLevel>();
        stats = FindObjectOfType<GameStateWC>();
        CountBreakableWords(); 

        GetComponent<Rigidbody2D>().velocity = new Vector2(0,-5);
    }
    private void CountBreakableWords()
    {
        level.CountBreakableWords();
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name=="Paddle")
        {
            Destroy(gameObject);
            level.WordsDestroyed();
            if(gameObject.tag == "IT")
            {
            stats.AddToScore();
            } 
            if(gameObject.tag == "Non-IT")
            {
            stats.SubToScore();
            }           
        }
        if(collision.gameObject.name=="Ground")
        {
            Destroy(gameObject);
            level.WordsDestroyed();
        }
    }
}
