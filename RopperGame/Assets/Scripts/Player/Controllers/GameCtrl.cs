using UnityEngine;
using System.Collections;
using System;

public class GameCtrl : PlayerCtrlMode
{

    //The climber we are using
    private RopperGuy mRopper;

	public GameCtrl() : base(CtrlType.GAME)
    {
        mRopper = null;
    }

    public override void Activate()
    {
        
    }

    public override void Terminate()
    {
        
    }

    public override void OnTap(Touch _touch)
    {
        
    }

    public override void OnTap(KeyCode _keyCode)
    {
        
    }
}
