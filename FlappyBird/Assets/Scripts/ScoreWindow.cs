using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    [SerializeField] private GameObject m_Emre;

    [SerializeField] private Text highscoreText;
    private Text scoreText; 
    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();

    }

    private void Start()
    {
        highscoreText.text = "HIGHSCORE: " + Score.GetHighscore().ToString();
        Bird.GetInstance().OnDied += ScoreWindow_OnDied;
        Bird.GetInstance().OnStartedPlaying += ScoreWindow_OnStartedPlaying;
        Hide();

    }

    private void ScoreWindow_OnStartedPlaying(object sender, EventArgs e)
    {
        Show();
    }

    private void ScoreWindow_OnDied(object sender, EventArgs e)
    {
        Hide();

    }

    private void Update()
    {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();

        if (Input.GetKeyDown("a"))
        {
            Instantiate(m_Emre);
        }
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
