using UnityEngine;
using System.Collections;
using System;

public class RefillEnergyCommand : ICommand
{

    public RefillEnergyCommand()
    {
        
    }

    public override void Execute()
    {
        //Get the energy bar
        if(PlayerFSM.GetCurrentCtrlMode().GetCtrlType() == CtrlType.GAME)
        {
            GameCtrl tCtrl = (GameCtrl)PlayerFSM.GetCurrentCtrlMode();

            tCtrl.GetRopperGuy().ResetEnergy();
        }
    }
}
