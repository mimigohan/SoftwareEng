using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBLevel : MonoBehaviour
{
    [SerializeField] int blocks;
    
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        blocks++;
    }

    public void BlockDestroyed(){
        blocks--;
        if(blocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
