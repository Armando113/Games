using UnityEngine;
using System.Collections;

public class GameStateMachine
{

    private static GameStateMachine pInstance;

    private ScreenState currentScreen;
    private ScreenState previousScreen;

    private ScreenState menuScreen;
	private ScreenState introScreen;
    private ScreenState gameScreen;
    private ScreenState gameOverScreen;

    private bool canPlay;

    private GameStateMachine()
    {
        //Create the states
        //Menu
        menuScreen = new MenuScreen();

		//Intro
		introScreen = new IntroScreen();

        //Game
        gameScreen = new GameScreen();

        //Game Over
        gameOverScreen = new GameOverScreen();

        //canPlay is false
        canPlay = false;

        //Enter the menu screen
        currentScreen = menuScreen;
    }

    private static GameStateMachine GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new GameStateMachine();
        }
        return pInstance;
    }

    private void ChangeState(ScreenState _state)
    {
        if(_state != null)
        {
            //Exit the current state
            currentScreen.Exit();

            //record current state
            previousScreen = currentScreen;

            //Get new Screen
            currentScreen = _state;

            //Enter new screen
            currentScreen.Enter();
        }
    }

    public static void Execute()
    {
        GetInstance().currentScreen.Execute();
    }

	public static void EnterMenuScreen()
    {
        GetInstance().canPlay = false;
        GetInstance().ChangeState(GetInstance().menuScreen);
    }
	public static void EnterIntroScreen()
	{
		GetInstance().canPlay = false;
		GetInstance().ChangeState(GetInstance().introScreen);
	}

    public static void EnterGameScreen()
    {
        GetInstance().canPlay = true;
        GetInstance().ChangeState(GetInstance().gameScreen);
    }

    public static void EnterGOScreen()
    {
        GetInstance().canPlay = false;
        GetInstance().ChangeState(GetInstance().gameOverScreen);
    }

    public static bool CanPlay()
    {
        return GetInstance().canPlay;
    }
}
