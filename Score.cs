using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreT;
    int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = PlayerPrefs.GetInt("score");
        ScoreT.text = "Score = " + playerScore;
        Console.Write(playerScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    
}
