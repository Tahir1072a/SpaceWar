using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int playerScore;

    public static ScoreKeeper Instance { get; set; }
    private void Awake()
    {
        ManageSingelton();
    }

    private void ManageSingelton()
    {
        if(Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetCurrentScore()
    {
        return playerScore;
    }

    public void ModifyScore(int score)
    {
        playerScore += score;
        Mathf.Clamp(score, 0,int.MaxValue);
    }
    public void ResetScore()
    {
        playerScore = 0;
    }
}
