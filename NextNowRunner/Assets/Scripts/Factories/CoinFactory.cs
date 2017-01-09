using UnityEngine;
using System.Collections;

public class CoinFactory
{

    private CoinFactory()
    {

    }

    public static Coin CreateCoin()
    {
        ItemTree mTree = (ItemTree)GameObjectManager.GetTree(BaseType.ITEM);
        if (mTree != null)
        {
            //we got the tree, get a floor block
            Coin coin = mTree.GetCoin();
            return coin;
        }

        return null;
    }

    public static void ReturnCoin(Coin _coin)
    {
        ItemTree mTree = (ItemTree)GameObjectManager.GetTree(BaseType.ITEM);
        if (mTree != null)
        {
            //we got the tree, get a floor block
            mTree.ReturnCoin(_coin);
        }
    }
}
