using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    private Text scoreUi;
    public Text highScore;
    float score;
    private void Start()
    {
        scoreUi = GetComponent<Text>();
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
        score = float.Parse(scoreUi.text.ToString());
    }
    private void Update()
    {
        if (!FindObjectOfType<GameManager>().isEnded())
        {
            score += Time.timeSinceLevelLoad / 5;
            scoreUi.text = score.ToString("0");
        }   
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            highScore.text = score.ToString("0");
        }
    }
}
