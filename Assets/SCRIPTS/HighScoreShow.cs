using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreShow : MonoBehaviour
{
    private Text highScore;
    private void Start()
    {
        highScore = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
    }
}
