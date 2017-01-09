using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{

    public Text scoreText;
    public Text healthText;
    public Text finalScore;

    private static Text privScoreText;
    private static Text privHealthText;
    private static Text privFinalScore;

	// Use this for initialization
	void Start ()
    {
        privScoreText = scoreText;
        privHealthText = healthText;
        privFinalScore = finalScore;
	}
	
	public static Text GetScoreText()
    {
        return privScoreText;
    }

    public static Text GetHealthText()
    {
        return privHealthText;
    }

    public static Text GetFinalScoreText()
    {
        return privFinalScore;
    }
}
