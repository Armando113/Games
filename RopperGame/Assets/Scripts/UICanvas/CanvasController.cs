using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void SwitchToMenu()
    {
        GameStateMachine.EnterMenuScreen();

    }

	public void SwitchToIntro()
	{
		GameStateMachine.EnterIntroScreen ();
	}

    public void SwitchToGame()
    {
        GameStateMachine.EnterGameScreen();
    }

}
