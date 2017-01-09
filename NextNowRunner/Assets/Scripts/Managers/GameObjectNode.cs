using UnityEngine;
using System.Collections;

public class GameObjectNode : NodeLink
{

    protected TreeComponent myTree;

    protected GameObjectNode(BaseType _type) : base(_type)
    {

    }

    public TreeComponent GetTree()
    {
        return myTree;
    }

    public void Activate()
    {
        if(myTree != null)
        {
            myTree.ActivateObject();
        }
    }

    public void Deactivate()
    {
        if (myTree != null)
        {
            myTree.DeactivateObject();
        }
    }

}
