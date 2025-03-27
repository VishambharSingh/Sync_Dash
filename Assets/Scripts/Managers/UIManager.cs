using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject gamePlay;
    public Button playBtn;
    public Button quitBtn;
    public Button restartBtn;
    public Button mainMenuBtn;

    private void OnEnable()
    {
        playBtn.onClick.AddListener(() =>
        {
            StartGame();
        }); 
        restartBtn.onClick.AddListener(() =>
        {
            RestartGame();
        });
         mainMenuBtn.onClick.AddListener(() =>
        {
            RestartGame();
        });
         quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
        
    }
    private void OnDisable()
    {
        playBtn.onClick.RemoveAllListeners();
        restartBtn.onClick.RemoveAllListeners();
        mainMenuBtn.onClick.RemoveAllListeners();
        quitBtn.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        Instance = this;
    }

    private void StartGame()
    {
        
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        gamePlay.SetActive(true);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
}
