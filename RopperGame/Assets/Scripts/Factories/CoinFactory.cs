using UnityEngine;
using System.Collections;

public class CoinFactory
{
    //Dafuq is up with my names....
    private CoinFactory()
    {

    }

    public static Coins GetCoin()
    {
        //Get the Coin tree
        CoinsTree CoinTree = (CoinsTree)GameObjectManager.GetTree(GameObjectType.ITEM);
        if (CoinTree != null)
        {
            Coins tCoin = (Coins)CoinTree.LoanObject();
            if (tCoin != null)
            {
                return tCoin;
            }
        }

        //Something went wrong
        return null;
    }
    public static Coins DontCoin()
    {
        
        //Something went wrong
        return null;
    }
  
    //Be green and recycle your blocks :) (Insert more greenpeace shit here) :P
    public static void ReturnCoin(Coins _Coin)
    {
        //Get the Coin tree!
        CoinsTree tTree = (CoinsTree)GameObjectManager.GetTree(GameObjectType.ITEM);
        //Check if the tree isn't null
        if (tTree != null)
        {
            //Return the object
            tTree.ReturnObject(_Coin);
        }
    }

}