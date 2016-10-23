using UnityEngine;
using System.Collections;

public class PlayerFSM : FSM
{
    private static PlayerFSM pInstance;

    private LLRopeLane llLane;
    private RRRopeLane rrLane;

    //Our controllers
    private PlayerCtrlMode mCurrCtrl;
    private GameCtrl mGameCtrl;

    public RopperGuy climber;

    private PlayerFSM() : base(null)
    {
        llLane = new LLRopeLane();
        rrLane = new RRRopeLane();

        //Add the neighbours
        //Add for LL
        llLane.SetLeftLane(null);
        llLane.SetRightLane(rrLane);
        //Add for RR
        rrLane.SetLeftLane(llLane);
        rrLane.SetRightLane(null);


        //Set the new current state
        currentState = rrLane;

    }

    private static PlayerFSM GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new PlayerFSM();
        }
        return pInstance;
    }

    //The types of commands the player can give
    public static void OnTap(KeyCode _keyCode)
    {
        GetInstance().mCurrCtrl.OnTap(_keyCode);
    }
    public static void OnTap(Touch _touch)
    {
        GetInstance().mCurrCtrl.OnTap(_touch);
    }

    public static void MoveToRight()
    {
        //Get the next node
        RopeLane currentLane = (RopeLane)GetInstance().currentState;

        if(currentLane.GetRightLane() != null)
        {
            GetInstance().ChangeState(currentLane.GetRightLane());

            //Execute the state
            GetInstance().currentState.Execute(GetInstance().climber);
        }
        else
        {
            GetInstance().currentState.Execute(GetInstance().climber);
        }
    }

    public static void MoveToLeft()
    {
        //Get the next node
        RopeLane currentLane = (RopeLane)GetInstance().currentState;

        if (currentLane.GetLeftLane() != null)
        {
            GetInstance().ChangeState(currentLane.GetLeftLane());

            //Execute the state
            GetInstance().currentState.Execute(GetInstance().climber);
        }
        else
        {
            GetInstance().currentState.Execute(GetInstance().climber);
        }
    }

    public static void SetRopper(RopperGuy _climber)
    {
        GetInstance().climber = _climber;
    }

    public static void DrainEnergy(float _energy)
    {
        GetInstance().climber.DrainEnergy(_energy);

    }

    public static void ResetRopper()
    {
        GetInstance().currentState = GetInstance().rrLane;

        RopperTree tTree = (RopperTree)GameObjectManager.GetTree(GameObjectType.PLAYER);

        SetRopper(tTree.GetRopperGuy());

        //Reposition the ropper guy
        if (GetInstance().climber != null)
        {
            GetInstance().climber.ForceNewPosition(Vector3.zero);
            GetInstance().climber.gameObject.SetActive(true);
        }
    }

    public static void DeactivateRopper()
    {
        if (GetInstance().climber != null)
        {
            GetInstance().climber.gameObject.SetActive(false);
        }
    }

}
