using UnityEngine;
using System.Collections;
using System;

public class GameCtrl : PlayerCtrlMode
{

    //The climber we are using
    private RopperGuy mRopper;

    //Lanes
    private LLRopeLane llLane;
    private RRRopeLane rrLane;
    private RopeLane currentLane;

    public GameCtrl() : base(CtrlType.GAME)
    {
        mRopper = null;

        llLane = new LLRopeLane();
        rrLane = new RRRopeLane();

        //Add the neighbours
        //Add for LL
        llLane.SetLeftLane(null);
        llLane.SetRightLane(rrLane);
        //Add for RR
        rrLane.SetLeftLane(llLane);
        rrLane.SetRightLane(null);

        currentLane = rrLane;
    }

    public override void Activate()
    {
        //Get the ropper from the tree
        if(mRopper == null)
        {
            mRopper = RopperGuyFactory.GetRopperGuy();
        }

        if(mRopper != null)
        {
            //Activate
            mRopper.gameObject.SetActive(true);
            mRopper.SetFallen(false);
        }
    }

    public override void Terminate()
    {
        if (mRopper != null)
        {
            //Deactivate
            mRopper.gameObject.SetActive(false);
            RopperGuyFactory.ReturnRopperGuy(mRopper);
            mRopper = null;
        }
    }

    public override void OnTap(Touch _touch)
    {
        if(!mRopper.IsFalling())
        {
            //If all goes well, row!!
            //Shout Row!!! o.o
            FloorManager.RowFloor();

            //Get the touch
            if (_touch.position.x > (Screen.width / 2.0f))
            {
                //We are in the right side
                if (currentLane.GetRightLane() == null)
                {
                    currentLane.Execute(mRopper);
                }
                else
                {
                    ChangeLane(currentLane.GetRightLane());
                    currentLane.Execute(mRopper);
                }
            }
            else
            {
                //We are in the right side
                if (currentLane.GetLeftLane() == null)
                {
                    currentLane.Execute(mRopper);
                }
                else
                {
                    ChangeLane(currentLane.GetLeftLane());
                    currentLane.Execute(mRopper);
                }
            }
            //Score points!
            ScoreManager.AddPoint();
        }
    }

    public override void OnTap(KeyCode _keyCode)
    {
        if(!mRopper.IsFalling())
        {
            if (_keyCode == KeyCode.Mouse0)
            {
                //If all goes well, row!!
                //Shout Row!!! o.o
                FloorManager.RowFloor();
                //Get the touch
                if (Input.mousePosition.x > (Screen.width / 2.0f))
                {
                    //We are in the right side
                    if (currentLane.GetRightLane() == null)
                    {
                        currentLane.Execute(mRopper);
                    }
                    else
                    {
                        ChangeLane(currentLane.GetRightLane());
                        currentLane.Execute(mRopper);
                    }
                }
                else
                {
                    //We are in the right side
                    if (currentLane.GetLeftLane() == null)
                    {
                        currentLane.Execute(mRopper);
                    }
                    else
                    {
                        ChangeLane(currentLane.GetLeftLane());
                        currentLane.Execute(mRopper);
                    }
                }
                //Score points!
                ScoreManager.AddPoint();
            }
        }
    }

    public RopperGuy GetRopperGuy()
    {
        return mRopper;
    }

    private void ChangeLane(RopeLane _newLane)
    {
        if(_newLane != null)
        {
            currentLane.Exit(mRopper);

            currentLane = _newLane;

            currentLane.Enter(mRopper);
        }
    }
}
