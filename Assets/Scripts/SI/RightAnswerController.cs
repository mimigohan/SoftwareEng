using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RightAnswerController : MonoBehaviour
{
    SceneLoader sceneLoader;
    private Transform rightAC;
    public Text winText;
    void Start()
    {

        sceneLoader = FindObjectOfType<SceneLoader>();
        winText.enabled = false;
        rightAC = GetComponent<Transform>();
    }

    void Update()
    {
        if (rightAC.childCount == 0)
        {
            winText.enabled = true;
            StartCoroutine(EndOfGame());

        }


    }
    IEnumerator EndOfGame()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        //SceneManager.LoadScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
       
    //}
}


