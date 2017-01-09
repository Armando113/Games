using UnityEngine;
using System.Collections;

public class FloorGenerator : SceneObject
{
    //floor list
    private BDQueue<FloorBlock> floorQueue;

    //distance to reset a floor
    private float fMaxResetDist;

    public Player mPlayer;

    public FloorGenerator() : base(BaseType.GENERATOR)
    {
        floorQueue = new BDQueue<FloorBlock>();
        fMaxResetDist = 40.0f;
    }

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GSM.CanPlay())
        {
            MoveFloors();
        }
	}

    public override void ActivateObject()
    {
        //Get 5 floors
        for(int i = 0; i < 5; i++)
        {
            //Create a block
            floorQueue.EnqueueFront(FloorFactory.CreateFloor());
            //Move the block
            floorQueue.PeekFront().transform.position = new Vector3((i * floorQueue.PeekFront().transform.localScale.x), 0.0f, 0.0f);
        }
    }

    public override void DeactivateObject()
    {
        while(floorQueue.PeekFront() != null)
        {
            FloorFactory.ReturnFloor(floorQueue.PopFront());
        }
    }

    private void MoveFloors()
    {
        if(mPlayer == null)
        {
            mPlayer = PlayerFactory.GetPlayerReference();
        }

        if(mPlayer == null)
        {
            return;
        }

        if (Vector3.Distance(floorQueue.PeekFront().GetPosition(), mPlayer.GetPosition()) > fMaxResetDist)
        {
            //Move floor 
            FloorBlock block = floorQueue.PopFront();
            //Move it to the further back
            block.transform.position = new Vector3(floorQueue.PeekBack().transform.position.x + block.transform.localScale.x, 0.0f, 0.0f);
            //add to the back
            floorQueue.EnqueueBack(block);
        }
    }
}
