using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    Text scoreDis;
    public Text saveScore;
    private void Start()
    {
        scoreDis = GetComponent<Text>();
        scoreDis.text = saveScore.text;
    }

}
