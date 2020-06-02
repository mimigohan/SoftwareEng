using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WCLevel : MonoBehaviour
{
   
    [SerializeField] int words;
    
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableWords()
    {
        words++;
    }
    public void WordsDestroyed(){
        words--;
        if(words <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
