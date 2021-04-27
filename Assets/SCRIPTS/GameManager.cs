using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;
    private bool end;
    public static GameManager instance = null; //Singlton
    public GameObject losePanel, player, spawner;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            return;
        end = false;
    }
    public void GameEnded()
    {
        end = true;
        StartCoroutine(RestartLevel());
        FindObjectOfType<ObstacleMovement>().SaveSpeed(500f);
    }
    public bool isEnded()
    {
        return end;
    }
    IEnumerator RestartLevel()
    {
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = 0.002f;
        yield return new WaitForSeconds(1f / 10);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        losePanel.SetActive(true);
        player.SetActive(false);
        spawner.SetActive(false);
    }
}
