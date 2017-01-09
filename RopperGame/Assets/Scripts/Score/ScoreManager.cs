using UnityEngine;
using System.Collections;

public class ScoreManager
{

    private static ScoreManager pInstance;

    private int currentScore;

    private int highScore;

    private ScoreManager()
    {
        currentScore = 0;

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private static ScoreManager GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new ScoreManager();
        }
        return pInstance;
    }

    
    public static void AddPoint()
    {
        GetInstance().currentScore += 1;

        if(GameScreenController.GetScoreText() != null)
        {
            GameScreenController.GetScoreText().text = GetInstance().currentScore.ToString();
        }
    }

    public static int GetCurrentScore()
    {
        return GetInstance().currentScore;
    }

    public static void ResetScore()
    {
        GetInstance().currentScore = 0;
        if (GameScreenController.GetScoreText() != null)
        {
            GameScreenController.GetScoreText().text = GetInstance().currentScore.ToString();
        }
    }

    public static int GetHighScore()
    {
        return GetInstance().highScore;
    } 

    public static void RecordNewScore()
    {
        if(GetInstance().currentScore > GetInstance().highScore)
        {
            GetInstance().highScore = GetInstance().currentScore;

            PlayerPrefs.SetInt("HighScore", GetInstance().highScore);
        }
    }
	
    public static void ShowScores()
    {
        if(GOScreenController.GetScoreText() != null)
        {
            GOScreenController.GetScoreText().text = GetInstance().currentScore.ToString();
        }

        if(GOScreenController.GetBestText() != null)
        {
            GOScreenController.GetBestText().text = GetInstance().highScore.ToString();
        }
    }
}
