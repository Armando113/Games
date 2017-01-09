using UnityEngine;
using System.Collections;

public class PlayerFactory
{

	public static Player GetPlayerReference()
    {
        PlayerTree mTree = (PlayerTree)GameObjectManager.GetTree(BaseType.PLAYER);
        if (mTree != null)
        {
            //we got the tree, get a floor block
            Player player = mTree.GetPlayer();
            return player;
        }
        return null;
    }
}
