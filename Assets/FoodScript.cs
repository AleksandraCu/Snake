using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public SnakeScript snake;
    public int playerScore;
    public Text scoreText;
    public int highScore;
    public Text highScoreText;
    public GameObject gameOverScreen;

    private void Start()
    {
        RandomizePosition();
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    public void addScore()
    {
            playerScore += 1;
            scoreText.text = "SCORE: " + playerScore.ToString();

        if (playerScore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", playerScore);
            highScoreText.text = "HIGHSCORE: " + playerScore.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomizePosition();
            addScore();
        }
    }
}
