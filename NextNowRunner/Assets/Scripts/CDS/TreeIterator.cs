using UnityEngine;
using System.Collections;

public class TreeIterator
{

    private TreeComponent myNode;

    public TreeIterator()
    {
        myNode = null;
    }

    public void SetNode(TreeComponent _node)
    {
        myNode = _node;
    }

    public TreeComponent GetNode()
    {
        return myNode;
    }

    public void GoNext()
    {
        if(myNode != null)
        {
            myNode = (TreeComponent)myNode.GetNext();
        }
    }

    public void GoPrev()
    {
        if (myNode != null)
        {
            myNode = (TreeComponent)myNode.GetPrev();
        }
    }

}
