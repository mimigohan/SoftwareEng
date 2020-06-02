using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class GameState : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointGain = 100;
    [SerializeField] int lives = 3;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled = false;

    int score = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = ""+score;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

         if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Main Menu");
            Destroy(gameObject);
         }
    }

    public void AddToScore()
    {
        score += pointGain;
        scoreText.text = ""+score;
    }

    public void ResetGame(bool menu){
        Debug.Log("Inside Reset Game");
        if (menu){
            Debug.Log("Menu Button Pressed.");
            FindObjectOfType<SceneLoader>().MainMenu();
        }
        else{
            Debug.Log("Reset Button Pressed.");
            FindObjectOfType<SceneLoader>().LoadBlockBreaker();
        }
            
        Debug.Log("Destroyed.");
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }

    public bool LooseLive(){
        lives--;

        return (lives <= 0);
    }
}
