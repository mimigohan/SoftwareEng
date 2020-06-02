using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame(){
        Application.Quit();    
    }

    public void LoadBlockBreaker(){
        SceneManager.LoadScene("Block Breaker Start");
    }

    public void LoadSpaceInvader(){
        SceneManager.LoadScene("SI_StartA");
    }
    public void LoadWordCatcher(){
        SceneManager.LoadScene("WC Start");
    }
}
