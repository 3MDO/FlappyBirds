using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score 
{
    public static void Start()
    {
        //ResetHighScore();
        Bird.GetInstance().OnDied += Bird_OnDied;
    }

    private static void Bird_OnDied(object sender, EventArgs e)
    {
        TrySetNewHighscore(Level.GetInstance().GetPipesPassedCount());
    }

    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt("highscore");
    }
    public static bool TrySetNewHighscore(int score)
    {
        int currentHighscore = GetHighscore();

        if (score > currentHighscore)
        {//new Highscore
            PlayerPrefs.SetInt("highscore", score);
           // Debug.LogError(PlayerPrefs.set());
            PlayerPrefs.Save();
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void ResetHighScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
        PlayerPrefs.Save();
    }
}
