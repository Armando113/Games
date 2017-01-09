using UnityEngine;
using System.Collections;

public class FloorManager
{
    private static FloorManager pInstance;

    private BDQueue<Floor> myFloors;

    private bool isCreated;

    private FloorManager()
    {
        isCreated = false;
        //Create new Queue
        myFloors = new BDQueue<Floor>();
    }

    private static FloorManager GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new FloorManager();
        }
        return pInstance;
    }

    public static void CreateFloors()
    {
        if(!GetInstance().isCreated)
        {
            //Set them up
            for (int i = 0; i < GameRules.GetMaxBlocks(); i++)
            {
                //Create a new Floor
                Floor nuFloor = new Floor();

                //Generate new assets
                nuFloor.GetNewAssets(i-1);

                nuFloor.SetPosition(new Vector3(0.0f, (i * BuildingBlock.BlockHeight) - BuildingBlock.BlockHeight, 0.0f));

                //Enqueue the node to the back (like mortals purchasing tckets in a cinema)
                GetInstance().myFloors.EnqueueBack(nuFloor);

                GetInstance().isCreated = true;
            }
        }
    }

    //Called when we exit the Game Mode
    public static void DeleteFloors()
    {
        if(GetInstance().isCreated)
        {
            //Walk the queue, and tell every floor to delete assets
            for(int i = 0; i < GetInstance().myFloors.GetSize(); i++)
            {
                //Tell the current floor to return assets
                GetInstance().myFloors[i].DeleteAssets();
            }

            //Clear the queue
            GetInstance().myFloors.ClearQueue();

            //Flag isCreated to false
            GetInstance().isCreated = false;
        }
    }

    public static void RowFloor()
    {
        //are the floors created yet?
        if(GetInstance().isCreated && !AreFloorsRowing())
        {
            //Give out commands to our floors
            for(int i = 0; i < GameRules.GetMaxBlocks(); i++)
            {
                //Are we not the head?
                if(GetInstance().myFloors[i] != GetInstance().myFloors.PeekFront())
                {
                    //Move to the next position
                    GetInstance().myFloors[i].Row(GetInstance().myFloors[i + 1].GetBlock().transform.position);
                }
                else
                {
                    //We are at the head
                    //Move the head to the tail's position
                    GetInstance().myFloors.PeekFront().Row(GetInstance().myFloors.PeekBack().GetBlock().transform.position);

                    //Get the Head
                    Floor tHead = GetInstance().myFloors.PopFront();
                    //Move it to the back
                    GetInstance().myFloors.EnqueueBack(tHead);

                    //Reset its contents
                    tHead.ResetContent();
                }
                
            }
        }
    }

    public static bool AreFloorsRowing()
    {
        //Walk the list of floors and check if they are not rowing
        for(int i = 0; i < GameRules.GetMaxBlocks(); i++)
        {
            if(GetInstance().myFloors[i].IsRowing())
            {
                return true;
            }
        }


        return false;
    }

    //This function returns the rope type on the right side
    public static RopeEnum GetRightRopeOnFloor(int _floor)
    {
        return GetInstance().myFloors[_floor].GetRightRope().GetRopeType();
    }

    //This function returns the rope type on the left side
    public static RopeEnum GetLeftRopeOnFloor(int _floor)
    {
        return GetInstance().myFloors[_floor].GetLeftRope().GetRopeType();
    }
    //This function returns the coins on the right side
    public static bool GetRightCoinOnFloor(int _floor)
    {
        return GetInstance().myFloors[_floor].CollectRightCoin();
    }

    //This function returns the Coins on the left side
    public static bool GetLeftCoinOnFloor(int _floor)
    {
        return GetInstance().myFloors[_floor].CollectLeftCoin();
    }

}
