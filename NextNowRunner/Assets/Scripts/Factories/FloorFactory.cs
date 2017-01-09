using UnityEngine;
using System.Collections;

public class FloorFactory
{

	private FloorFactory()
    {

    }

    public static FloorBlock CreateFloor()
    {
        FloorTree mTree = (FloorTree)GameObjectManager.GetTree(BaseType.FLOOR);
        if(mTree != null)
        {
            //we got the tree, get a floor block
            FloorBlock block = mTree.GetFloorBlock();
            return block;
        }

        return null;
    }

    public static void ReturnFloor(FloorBlock _block)
    {
        if (_block == null)
        {
            return;
        }

        FloorTree mTree = (FloorTree)GameObjectManager.GetTree(BaseType.FLOOR);
        if (mTree != null)
        {
            //we got the tree, get a floor block
            mTree.ReturnFloorBlock(_block);
        }

    }
}
