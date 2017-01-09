using UnityEngine;
using System.Collections;

public class WallGenerator : SceneObject
{

    private Player mPlayer;
    private BDQueue<RedWall> wallQueue;
    private float fMaxResetDist;

    public WallGenerator() : base(BaseType.OBSTACLE)
    {
        wallQueue = new BDQueue<RedWall>();
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
            MoveWalls();
        }
	}

    private void MoveWalls()
    {
        if (mPlayer == null)
        {
            mPlayer = PlayerFactory.GetPlayerReference();
        }

        if (mPlayer == null)
        {
            return;
        }

        if (Vector3.Distance(wallQueue.PeekFront().GetPosition(), mPlayer.GetPosition()) > fMaxResetDist)
        {
            //Move floor 
            RedWall wall = wallQueue.PopFront();
            //Move it to the further back
            wall.transform.position = new Vector3(wallQueue.PeekBack().transform.position.x + 20.0f, 1.0f, 0.0f);
            //add to the back
            wallQueue.EnqueueBack(wall);
            //Reactivate
            wallQueue.PeekBack().gameObject.SetActive(true);
        }
    }

    public override void ActivateObject()
    {
        //Get 5 floors
        for (int i = 0; i < 5; i++)
        {
            //Create a block
            wallQueue.EnqueueFront(WallFactory.CreateWall());
            //Move the block
            wallQueue.PeekFront().transform.position = new Vector3((i * 20.0f) + 17.5f, 1.0f, 0.0f);
        }
    }

    public override void DeactivateObject()
    {
        while (wallQueue.PeekFront() != null)
        {
            WallFactory.ReturnWall(wallQueue.PopFront());
        }
    }
}
