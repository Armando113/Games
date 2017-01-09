using UnityEngine;
using System.Collections;

public class GSM
{
    private static GSM pInstance;

    private GameState currentState;
    private GameState previousState;

    private GameState introState;
    private GameState gameState;
    private GameState gameOverState;

    private ControllSubject mySubject;
    private EndSubject endSubject;

    private bool canPlay;

    private GSM()
    {
        //Intro scene
        introState = new IntroState();

        //The game state
        gameState = new PlayState();

        //Game over state
        gameOverState = new GameOverState();

        //Can play starts as false
        canPlay = false;

        mySubject = new ControllSubject();
        endSubject = new EndSubject();

        //we start at intro
        currentState = introState;
        //Enter the state
        currentState.Enter();
    }

    private static GSM GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new GSM();
        }
        return pInstance;
    }

    public static void Kickstart()
    {
        GetInstance();
    }

    public void ChangeState(GameState _state)
    {
        if(_state != null)
        {
            //Exit the current state
            currentState.Exit();

            //record current state
            previousState = currentState;

            //Get new Screen
            currentState = _state;

            //Enter new screen
            currentState.Enter();
        }
    }

    public static void EnterGame()
    {
        //Can play is true
        GetInstance().canPlay = true;
        //Change the state to game
        GetInstance().ChangeState(GetInstance().gameState);
        //Update observers
        GetInstance().mySubject.NotifyObservers();
    }

    public static void EnterGameOver()
    {
        //Can play is false
        GetInstance().canPlay = false;
        //Change the state to gameOver
        GetInstance().ChangeState(GetInstance().gameOverState);
        GetInstance().endSubject.NotifyObservers();
    }

    public static bool CanPlay()
    {
        return GetInstance().canPlay;
    }

    public static void RegisterObserver(Observer _observer)
    {
        if(_observer == null)
        {
            return;
        }
        //register observer
        GetInstance().mySubject.RegisterObserver(_observer);
    }

    public static void RemoveObserver(Observer _observer)
    {
        if(_observer == null)
        {
            return;
        }
        //Remove observer
        GetInstance().mySubject.RemoveObserver(_observer);
    }

    public static void RegisterEndObserver(Observer _observer)
    {
        if (_observer == null)
        {
            return;
        }
        //register observer
        GetInstance().endSubject.RegisterObserver(_observer);
    }

    public static void RemoveEndObserver(Observer _observer)
    {
        if (_observer == null)
        {
            return;
        }
        //Remove observer
        GetInstance().endSubject.RemoveObserver(_observer);
    }

}
