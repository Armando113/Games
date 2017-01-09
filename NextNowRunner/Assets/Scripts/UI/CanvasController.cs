using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}

    public void SwitchToGameOver()
    {
        GSM.EnterGameOver();
    }

    public void SwitchToGame()
    {
        GSM.EnterGame();
    }
}
