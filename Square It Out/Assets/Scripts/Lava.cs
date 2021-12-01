using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject highestScoreText;

    int lastScore;

    private void Start()
    {
        lastScore = 0;
    }

    void Update()
    {
        if (GameManager.canMove)
        {
            int scoreNow = GameManager.score;

            transform.position += transform.up * GameManager.speed * Time.deltaTime;

            if (scoreNow - lastScore > 10)
            {
                lastScore = scoreNow;
                GameManager.speed += 0.1f;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.playerSquares.Remove(collision.gameObject);
            Destroy(collision.gameObject);

            if (GameManager.playerSquares.Count == 0)
            {
                if (PlayerPrefs.GetInt("highestscore") < GameManager.score)
                {
                    highestScoreText.gameObject.SetActive(true);
                    PlayerPrefs.SetInt("highestscore", GameManager.score);
                }

                endPanel.SetActive(true);

                GameManager.canMove = false;
            }
        }
    }
}
