using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    public void resetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
    
}
