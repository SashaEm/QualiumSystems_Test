using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score = 0;

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void SaveScore()
    {
        var highScore = PlayerPrefs.GetInt("HighScore");
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
