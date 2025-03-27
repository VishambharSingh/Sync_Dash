using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private void OnEnable()
    {
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
        highScoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("Level", 1);
        ScoreManager.Instance.score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
