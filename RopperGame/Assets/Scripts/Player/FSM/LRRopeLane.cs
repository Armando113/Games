using UnityEngine;
using System.Collections;

public class LRRopeLane : RopeLane
{

    public override void Enter(TreeLeaf _object)
    {

    }

    public override void Execute(TreeLeaf _object)
    {
        //Cast the object as Ropper guy
        RopperGuy guy = (RopperGuy)_object;

        //Place at the center
        //guy.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
       
		guy.Row(new Vector3(0.0f, 0.0f, 0.0f));
        if (guy.transform.position != (new Vector3(0.0f, 0.0f, 0.0f)))
        {
            guy.GetComponentInChildren<Animator>().Play("Left2Middle");
        }
        
        if (guy.transform.position == (new Vector3(0.0f, 0.0f, 0.0f)))
        {
			guy.GetComponentInChildren<Animator>().Play(null);
            guy.GetComponentInChildren<Animator>().Play("Middle");
        }
        
       // guy.AddEnergy(GameRules.GetHighEnergy());

        //Check for weak ropes
        if (FloorManager.GetLeftRopeOnFloor(5) == RopeEnum.WEAK || FloorManager.GetRightRopeOnFloor(5) == RopeEnum.WEAK)
        {
            guy.GetComponentInChildren<Animator>().Play("Falling");
            EventManager.AddEvent(new GameOverCommand(), 0.3f);
        }

    }

    public override void Exit(TreeLeaf _object)
    {

    }
}
