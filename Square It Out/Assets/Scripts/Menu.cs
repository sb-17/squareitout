using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text highestScore;

    private void Start()
    {
        highestScore.text = " Highest Score: " + PlayerPrefs.GetInt("highestscore").ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void DiscordButton()
    {
        Application.OpenURL("https://discord.gg/9ERdXUBwEZ");
    }

    public void TwitterButton()
    {
        Application.OpenURL("https://twitter.com/lostin_games");
    }
}
