using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Eat : MonoBehaviour
{
    private int playerScore = 0;
    public new AudioSource[] audio;
    public Text scoreText, winText;

    void Start()
    {
        winText.text = "";
    }

    void Update()
    {
        SetScoreText();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Checks if the player is eating a pellet/pacdot
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
        else if(other.gameObject.tag == "Cherry")
        {
            Destroy(other.gameObject);
            playerScore += 100;
            audio[1].Play();
        }
    }


    void SetScoreText()
    {
        //Displays the score text and the win text
        scoreText.text = "Score: " + playerScore.ToString();
        if (playerScore >= 3250)
        {
            winText.text = "You Win!";
        }
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

}
