using UnityEngine;
using System.Collections;
using System;

public class RRRopeLane : RopeLane
{
    public override void Enter(TreeLeaf _object)
    {
        
    }

    public override void Execute(TreeLeaf _object)
    {
        //Cast the object as Ropper guy
        RopperGuy guy = (RopperGuy)_object;

        //Move it to the left
        guy.Row(new Vector3(0.55f, 0.0f, 0.0f));
        if (guy.transform.position == (new Vector3(0.55f, 0.0f, 0.0f)))
        {
            guy.GetComponentInChildren<Animator>().Play(null);
            guy.GetComponentInChildren<Animator>().Play("Right");

            if (FloorManager.GetRightCoinOnFloor(5) == true)
            {
                PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") + 1));
            }

        }

        if (guy.transform.position != (new Vector3(0.55f, 0.0f, 0.0f)))
        {
            guy.GetComponentInChildren<Animator>().Play("Middle2Right");
        }
        guy.AddEnergy(GameRules.GetLowEnergy());

        

        //Check for the right lane ONLY
        if (FloorManager.GetRightRopeOnFloor(5) == RopeEnum.WEAK)
        {
            guy.GetComponentInChildren<Animator>().Play("Falling");
            guy.SetFallen(true);
            EventManager.AddEvent(new GameOverCommand(), 0.3f);
        }
        
    }

    public override void Exit(TreeLeaf _object)
    {
        
    }
}
