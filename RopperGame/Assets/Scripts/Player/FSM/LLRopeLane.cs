using UnityEngine;
using System.Collections;

public class LLRopeLane : RopeLane
{
    public override void Enter(TreeLeaf _object)
    {

    }

    public override void Execute(TreeLeaf _object)
    {
        //Cast the object as Ropper guy
        RopperGuy guy = (RopperGuy)_object;

        //Move it to the left
        guy.Row(new Vector3(-0.55f, 0.0f, 0.0f));
        if (guy.transform.position != (new Vector3(-0.55f, 0.0f, 0.0f)))
        {
            guy.GetComponentInChildren<Animator>().Play("Middle2left");
        }
        guy.AddEnergy(GameRules.GetLowEnergy());


        if (guy.transform.position == (new Vector3(-0.55f, 0.0f, 0.0f))) 
        {
            guy.GetComponentInChildren<Animator>().Play(null);
            guy.GetComponentInChildren<Animator>().Play("Left");
            if (FloorManager.GetLeftCoinOnFloor(5) == true)
            {
                PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") + 1));
            }
        }
        //Check for the left lane ONLY
        if (FloorManager.GetLeftRopeOnFloor(5) == RopeEnum.WEAK)
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
