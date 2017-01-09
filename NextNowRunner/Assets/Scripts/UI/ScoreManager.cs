using UnityEngine;
using System.Collections;

public class ScoreManager
{

    private static ScoreManager pInstance;

    private int currentScore;

    private int currentHealth;

    private ScoreManager()
    {
        currentScore = 0;
        currentHealth = 3;
    }

    private static ScoreManager GetInstance()
    {
        if (pInstance == null)
        {
            pInstance = new ScoreManager();
        }
        return pInstance;
    }


    public static void AddPoint()
    {
        GetInstance().currentScore += 1;

        if (GamePanel.GetScoreText() != null)
        {
            GamePanel.GetScoreText().text = GetInstance().currentScore.ToString();
        }
    }

    public static void LoseHealth()
    {
        GetInstance().currentHealth -= 1;

        if(GamePanel.GetHealthText() != null)
        {
            GamePanel.GetHealthText().text = GetInstance().currentHealth.ToString();
        }
    }

    public static int GetCurrentScore()
    {
        return GetInstance().currentScore;
    }

    public static int GetCurrentHealth()
    {
        return GetInstance().currentHealth;
    }

    public static void Reset()
    {
        GetInstance().currentScore = 0;
        GetInstance().currentHealth = 3;
        if (GamePanel.GetScoreText() != null)
        {
            GamePanel.GetScoreText().text = GetInstance().currentScore.ToString();
        }
        if (GamePanel.GetHealthText() != null)
        {
            GamePanel.GetHealthText().text = GetInstance().currentHealth.ToString();
        }
    }
    public static void ShowScoreUI()
    {
        if (GamePanel.GetScoreText() != null)
        {
            GamePanel.GetScoreText().text = GetInstance().currentScore.ToString();
        }
        if (GamePanel.GetHealthText() != null)
        {
            GamePanel.GetHealthText().text = GetInstance().currentHealth.ToString();
        }
        if(GamePanel.GetFinalScoreText() != null)
        {
            GamePanel.GetFinalScoreText().text = GetInstance().currentScore.ToString();
        }
    }
}
