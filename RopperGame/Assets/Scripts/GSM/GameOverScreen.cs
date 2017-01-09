using UnityEngine;
using System.Collections;
using System;

public class GameOverScreen : ScreenState
{
	private RefillEnergyCommand energyRefill;

    public GameOverScreen() : base()
    {
		energyRefill = new RefillEnergyCommand();
    }

    public override void Enter()
    {
        //UI
        UIManager.SwitchToGameOver();
		EventManager.AddEvent(energyRefill, 0.0f);

        PlayerFSM.SetGameOverCtrl();
    }

    public override void Execute()
    {
        ScoreManager.ShowScores();
    }

    public override void Exit()
    {
		EventManager.StopEventTimer();
    }
}
