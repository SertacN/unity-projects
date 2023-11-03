using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Variables
    public TextMesh scoreText;
    public TextMesh lifeText;
    int score = 0;
    int life = 3;
  
    // When game start, set to score screen
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        lifeText.text = "Life: " + life.ToString();
    }
    // When player feed animals , score + 1
    public void AddScore(int value)
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
    // Lose 1 life when animal pass player in vertical side without feed
    public void LoseLife(int value)
    {
        life -= 1;
        lifeText.text = "Life: " + life.ToString();
        if(life < 1)
        {
            lifeText.text = "Game Over!";
        }
    }
    // Gameover when the player touch animal.
    public void GameOver()
    {
        lifeText.text = "Game Over";
    }
}
