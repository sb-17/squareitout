using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text text;
    public Text scoreText;
    public InputField input;
    public GameObject playerPrefab;
    public GameObject floorPrefab1;
    public TextAsset wordlist;

    public static int score;
    public static float speed = 0.7f;
    float jumpVelocity = 7f;
    static GameObject floorPrefab;
    public static bool canMove;

    public static List<GameObject> playerSquares = new List<GameObject>();
    public static List<GameObject> floors = new List<GameObject>();

    void Start()
    {
        playerSquares.Clear();
        floors.Clear();

        floorPrefab = floorPrefab1;

        score = 0;
        scoreText.text = "Score: " + score.ToString();

        speed = 0.7f;

        canMove = true;

        text.text = GetRandomWord();

        input.text = "";
        input.Select();

        GenerateNewFloor(-2f);
        GenerateNewFloor(0f);
        GenerateNewFloor(2f);
        GenerateNewFloor(4f);
        GenerateNewFloor(6f);
        GenerateNewFloor(8f);
        GenerateNewFloor(10f);

        CreateNewPlayer(Random.Range(-8f, 8f), floors[1].transform.position.y + 0.5f);
        CreateNewPlayer(Random.Range(-8f, 8f), floors[0].transform.position.y + 0.5f);
    }

    void Update()
    {
        if (input.text == text.text && canMove)
        {
            text.text = GetRandomWord();
            input.text = "";
            input.Select();

            for (int i = 0; i < playerSquares.Count; i++)
            {
                if (playerSquares[i].GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    jumpVelocity = 7 - playerSquares[i].GetComponent<Rigidbody2D>().velocity.y;
                }
                else
                {
                    jumpVelocity = 7 + playerSquares[i].GetComponent<Rigidbody2D>().velocity.y;
                }
                Jump(playerSquares[i].GetComponent<Rigidbody2D>(), jumpVelocity);
            }

            score += Mathf.RoundToInt(playerSquares.Count/2*Random.Range(1, 4));
            scoreText.text = "Score: " + score.ToString();

            CreateNewPlayer(Random.Range(-8f, 8f), floors[1].transform.position.y + 0.5f);
            GenerateNewFloor(floors[floors.Count - 1].transform.position.y + 2f);
        }
    }

    public void Jump(Rigidbody2D rb, float jumpVelocity)
    {
        rb.velocity = Vector2.up * jumpVelocity;
    }

    public void CreateNewPlayer(float x, float y)
    {
        playerSquares.Add(Instantiate(playerPrefab, new Vector3(x, y, 0f), Quaternion.identity));
    }

    public static void GenerateNewFloor(float y)
    {
        floors.Add(Instantiate(floorPrefab, new Vector3(0f, y, 0f), Quaternion.identity));
    }

    private string GetRandomWord()
    {
        var words = wordlist.text.Split('\n');

        var randomIndex = Random.Range(0, words.Length);

        return words[randomIndex].Remove(words[randomIndex].Length - 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
