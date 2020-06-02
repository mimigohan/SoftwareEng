using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits = 1;

    //cached reference
    BBLevel level;
    GameState stats;
    
    //state variables
    private int timesHit;

    private void Start()
    {
        level = FindObjectOfType<BBLevel>();
        stats = FindObjectOfType<GameState>();
        
        CountBreakableBlocks();
        
    }

    private void CountBreakableBlocks()
    {
        if(gameObject.tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void DestroyBlock(){
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        stats.AddToScore();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void HandleHit()
    {
            timesHit++;
            if(timesHit >= maxHits)
            {
                DestroyBlock();
            }
            
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(gameObject.tag == "Breakable")
        {
            HandleHit();
        }
    }
}
