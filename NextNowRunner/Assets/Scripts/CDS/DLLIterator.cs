using UnityEngine;
using System.Collections;

public class DLLIterator<T>
{
    DLLNode<T> myNode;

    public DLLIterator()
    {

    }

    public void SetNode(DLLNode<T> _node)
    {
        myNode = _node;
    }

    public void GoNext()
    {
        if(myNode != null)
        {
            myNode = myNode.GetNext();
        }
    }

    public void GoPrev()
    {
        if(myNode != null)
        {
            myNode = myNode.GetPrev();
        }
    }

    public DLLNode<T> GetNode()
    {
        return myNode;
    }
}
