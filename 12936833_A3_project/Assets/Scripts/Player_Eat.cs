using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Eat : MonoBehaviour
{
    private int playerScore = 0;
    public new AudioSource[] audio;
    public Text scoreText;

    void Start()
    {
        SetScoreText();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "PacDot")
        {
            Destroy(other.gameObject);
            playerScore += 10;
            audio[0].Play();
            scoreText.text = "Score: " + playerScore.ToString();
        }
        else if(other.gameObject.tag == "PowerUpDot")
        {
            Destroy(other.gameObject);
            playerScore += 50;
            audio[1].Play();
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

}
