using UnityEngine;
using System.Collections;
using System;

public class GameScreen : ScreenState
{

    private RefillEnergyCommand energyRefill;


	public GameScreen()
    {
        energyRefill = new RefillEnergyCommand();
	
    }

    public override void Enter()
    {
        //Initialize the Game assets
        //Create the floors
        FloorManager.CreateFloors();

        //UI
        UIManager.SwitchToGame();

        //Reset the Ropper
        PlayerFSM.SetGameCtrl();

        //Reset Score
        ScoreManager.ResetScore();

        //Turn on the event manager
        EventManager.StartEventTimer();

       
        //Add the energy command
        EventManager.AddEvent(energyRefill, 0.0f);
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        //Return all assets and dissapear
        FloorManager.DeleteFloors();

        //Turn off the Event Manager
        EventManager.StopEventTimer();

        //Record new Score
        ScoreManager.RecordNewScore();
    }
}
