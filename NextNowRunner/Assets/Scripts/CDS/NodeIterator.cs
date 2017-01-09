using UnityEngine;
using System.Collections;

public class NodeIterator
{

    NodeLink myNode;

    public NodeIterator()
    {

    }

    public void SetNode(NodeLink _node)
    {
        myNode = _node;
    }

    public void GoNext()
    {
        if (myNode != null)
        {
            myNode = myNode.GetNext();
        }
    }

    public void GoPrev()
    {
        if (myNode != null)
        {
            myNode = myNode.GetPrev();
        }
    }

    public NodeLink GetNode()
    {
        return myNode;
    }
}
