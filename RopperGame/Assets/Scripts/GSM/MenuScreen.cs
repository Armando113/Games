using UnityEngine;
using System.Collections;
using System;

public class MenuScreen : ScreenState
{
	

    public MenuScreen() : base()
    {


    }

    public override void Enter()
    {
        //Start (or activate) all assets in the main menu
        //UI
        UIManager.SwitchToMenu();

        PlayerFSM.SetMenuCtrl();
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
        
    }
}
