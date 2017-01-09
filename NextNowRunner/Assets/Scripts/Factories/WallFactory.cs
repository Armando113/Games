using UnityEngine;
using System.Collections;

public class WallFactory
{

    public static RedWall CreateWall()
    {
        ObstacleTree mTree = (ObstacleTree)GameObjectManager.GetTree(BaseType.OBSTACLE);
        if (mTree != null)
        {
            //we got the tree, get a floor block
            RedWall wall = mTree.GetRedWall();
            return wall;
        }

        return null;
    }

    public static void ReturnWall(RedWall _wall)
    {
        if (_wall == null)
        {
            return;
        }

        ObstacleTree mTree = (ObstacleTree)GameObjectManager.GetTree(BaseType.OBSTACLE);
        if (mTree != null)
        {
            //we got the tree, get a floor block
            mTree.ReturnRedWall(_wall);
        }

    }
}
