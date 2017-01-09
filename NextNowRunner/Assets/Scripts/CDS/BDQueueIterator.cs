using UnityEngine;
using System.Collections;

public class BDQueueIterator<T>
{
    private BDQueueNode<T> myNode;

    public BDQueueIterator()
    {
        myNode = null;
    }

    public void SetStartNode(BDQueueNode<T> _next)
    {
        myNode = _next;
    }

    public BDQueueNode<T> GetNode()
    {
        return myNode;
    }

    public void GoNext()
    {
        if(myNode != null)
        {
            myNode = myNode.GetNext();
        }
    }
	
}
