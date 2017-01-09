using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RopperGuyFactory
{

    private RopperGuyFactory()
    {

    }

    public static RopperGuy GetRopperGuy()
    {
        RopperTree tree = (RopperTree)GameObjectManager.GetTree(GameObjectType.PLAYER);
        if(tree != null)
        {
            RopperGuy tRopper = (RopperGuy)tree.LoanObject();
            if(tRopper != null)
            {
                return tRopper;
            }
        }

        return null;
    }

    public static void ReturnRopperGuy(RopperGuy _ropper)
    {
        if(_ropper != null)
        {
            RopperTree tree = (RopperTree)GameObjectManager.GetTree(GameObjectType.PLAYER);
            if (tree != null)
            {
                tree.ReturnObject(_ropper);
            }
        }
    }
}