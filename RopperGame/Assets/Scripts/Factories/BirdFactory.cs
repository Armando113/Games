using UnityEngine;
using System.Collections;

public class BirdFactory
{
    //Dafuq is up with my names....
    private BirdFactory()
    {

    }

    public static Birds CreateBird()
    {
        //Get the Bird tree!
        BirdTree tTree = (BirdTree)GameObjectManager.GetTree(GameObjectType.OBSTACLE);
        //Check if the tree isn't null
        if (tTree != null)
        {
            //Get a bird from the tree
            Birds tBird = (Birds)tTree.LoanObject();
            return tBird;
        }

        //Something went wrong
        return null;
    }

    //Be green and recycle your blocks :) (Insert more greenpeace shit here) :P
    public static void ReturnBird(Birds _bird)
    {
        //Get the Bird tree!
        BirdTree tTree = (BirdTree)GameObjectManager.GetTree(GameObjectType.OBSTACLE);
        //Check if the tree isn't null
        if (tTree != null)
        {
            //Return the object
            tTree.ReturnObject(_bird);
        }
    }

}