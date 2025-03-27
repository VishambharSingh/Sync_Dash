using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text mainOrbsScoreText;
    public Text mainScoreText;
    public Text ghostOrbsScoreText;
    public Text ghostScoreText;
    public float score = 0;
    public float ghostScore = 0;
    public int orbsScore = 0;
    public int ghostOrbsScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        //MakeSingleton();
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnEnable()
    {
        MyEvents.HitMainOrbs += AddMainOrbsScore;
        MyEvents.HitGhostOrbs += AddGhostOrbsScore;
        MyEvents.UpdateMainScore += AddScore;
        MyEvents.UpdateGhostScore += AddGhostScore;
    }

    private void OnDisable()
    {
        MyEvents.HitMainOrbs -= AddMainOrbsScore;
        MyEvents.HitGhostOrbs -= AddGhostOrbsScore;
        MyEvents.UpdateMainScore -= AddScore;
        MyEvents.UpdateGhostScore -= AddGhostScore;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore") == false)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
        AddScore(0);
    }

    public void AddScore(float amount)
    {
        score += amount;
        int finalScore = (int)score;
        if(score> PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
        PlayerPrefs.SetFloat("CurrentScore", score);
        mainScoreText.text = finalScore.ToString();
    }
    public void AddGhostScore(float amount)
    {
        score += amount;
        int finalScore = (int)score;
        ghostScoreText.text = finalScore.ToString();
    }

    void AddMainOrbsScore()
    {
        orbsScore++;
        mainOrbsScoreText.text = orbsScore.ToString();
    }
    void AddGhostOrbsScore()
    {
        ghostOrbsScore++;
        ghostOrbsScoreText.text = ghostOrbsScore.ToString();
    }
}
