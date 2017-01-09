using UnityEngine;
using System.Collections;

public class BDQueue<T>
{

    //Variables
    //The head
    protected BDQueueNode<T> pActiveHead;
    protected BDQueueNode<T> pActiveTail;
    protected BDQueueNode<T> pReserveHead;

    protected BDQueueIterator<T> pIterator;

    public BDQueue()
    {
        pActiveHead = null;
        pActiveTail = null;
        pReserveHead = null;

        //The iterator
        pIterator = new BDQueueIterator<T>();
    }

    //Overload [] operator
    public T this[int _index]
    {
        get
        {
            return GetAt(_index);
        }

        set
        {
            //Do nothing
        }
    }

    //Internal methods

    //Add to front
    protected BDQueueNode<T> AddFront(BDQueueNode<T> _node)
    {
        //check if the node isn't null
        if(_node != null)
        {
            //Case 1: The list is empty 
            if(pActiveHead == null && pActiveTail == null)
            {
                //The head points to node
                pActiveHead = _node;
                //The tail points to node
                pActiveTail = _node;
            }
            //Case 2: The list isn't empty
            else
            {
                //Head points to node
                pActiveHead.SetNext(_node);
                //Move the head
                pActiveHead = _node;
            }
        }

        return _node;
    }

    protected BDQueueNode<T> AddBack(BDQueueNode<T> _node)
    {
        //Check if it isn't null
        if(_node != null)
        {
            //Case 1: List is empty
            if(pActiveHead == null && pActiveTail == null)
            {
                //The head points to node
                pActiveHead = _node;
                //The tail points to node
                pActiveTail = _node;
            }
            //Case 2: The list isn't empty
            else
            {
                //Node points to tail
                _node.SetNext(pActiveTail);
                //Tail now points to node
                pActiveTail = _node;
            }
        }
        return _node;
    }
	
    protected BDQueueNode<T> PopReserve()
    {
        BDQueueNode<T> tResult = pReserveHead;

        if(tResult != null)
        {
            //Move the head
            pReserveHead = tResult.GetNext();

            //Unlink the node
            tResult.SetNext(null);
        }

        return tResult;
    }

    protected void AddReserve(BDQueueNode<T> _node)
    {
        //Check if not null
        if(_node != null)
        {
            //Case 1: The list is empty
            if(pReserveHead == null)
            {
                //Make the head the _node
                pReserveHead = _node;
            }
            //Case 2: The list empty
            else
            {
                //Link the node
                _node.SetNext(pReserveHead);
                //Move the head
                pReserveHead = _node;
            }
        }   
    }

    protected BDQueueNode<T> FindByData(T _data)
    {
        //Set the iterator to the tail
        pIterator.SetStartNode(pActiveTail);

        //Walk the list and find ther node
        while(pIterator.GetNode() != null)
        {
            //Check here
            if(pIterator.GetNode().GetData().Equals(_data))
            {
                return pIterator.GetNode();
            }

            //Keep walking Johnny
            pIterator.GoNext();
        }

        //Couldn't find the node with data
        return null;
    }

    protected BDQueueNode<T> GetPreviousNode(BDQueueNode<T> _currNode)
    {
        //Get the node behind us
        BDQueueNode<T> tResult = null;

        //Set iterator
        pIterator.SetStartNode(pActiveTail);

        //Quick check if the nide sent is the tail
        if(_currNode == pActiveTail)
        {
            return null;
        }

        //Walk the list
        while(pIterator.GetNode() != null)
        {
            //Check if the next one is us!
            if(pIterator.GetNode().GetNext() == _currNode)
            {
                tResult = pIterator.GetNode();
                break;
            }

            //Keep walking Johnny
            pIterator.GoNext();
        }

        return tResult;

    }

    protected BDQueueNode<T> RemoveFront()
    {
        //Capture the node
        BDQueueNode<T> tResult = null;
        //Case 1: there is only one node left
        if(pActiveHead == pActiveTail && pActiveHead != null)
        {
            tResult = pActiveHead;
            //Nullify the heads
            pActiveHead = null;
            pActiveTail = null;
        }
        //Case 2: there are more nodes in the list
        else if(pActiveHead != null)
        {
            //Get the result
            tResult = pActiveHead;

            //Move the head to the back
            pActiveHead = GetPreviousNode(pActiveHead);

            //Detach the head
            pActiveHead.SetNext(null);
        }
        return tResult;
    }

    protected BDQueueNode<T> RemoveBack()
    {
        //Capture the node
        BDQueueNode<T> tResult = null;
        //Case 1: there is only one node left
        if (pActiveHead == pActiveTail && pActiveHead != null)
        {
            tResult = pActiveTail;
            //Nullify the heads
            pActiveHead = null;
            pActiveTail = null;
        }
        //Case 2: there are more nodes in the list
        else if (pActiveTail != null)
        {
            //Get the result
            tResult = pActiveTail;

            //Move the tail to the next
            pActiveTail = pActiveTail.GetNext();

            //Detach the node
            tResult.SetNext(null);
        }
        return tResult;
    }

    protected T GetAt(int _index)
    {
        pIterator.SetStartNode(pActiveTail);

        int counter = 0;

        while(pIterator.GetNode() != null)
        {
            //Are we there yet ?
            if(counter == _index)
            {
                //We're here!
                return pIterator.GetNode().GetData();
            }
            //Count up
            counter++;
            //Kepp walking Johnny
            pIterator.GoNext();
        }

        //Should everything go to hell
        return default(T);
    }

    //Public methods

    public bool Contains(T _data)
    {
        BDQueueNode<T> tNode = FindByData(_data);

        if(tNode != null)
        {
            return true;
        }

        return false;
    }

    //Return the front data ONLY
    public T PeekFront()
    {
        if(pActiveHead != null)
        {
            return pActiveHead.GetData();
        }

        return default(T);
    }
    //Return the Tail data ONLY
    public T PeekBack()
    {
        if (pActiveTail != null)
        {
            return pActiveTail.GetData();
        }

        return default(T);
    }

    public void EnqueueFront(T _data)
    {
        BDQueueNode<T> tNode = PopReserve();

        if(tNode != null)
        {
            //Set node
            tNode.SetData(_data);

            //Add to list
            AddFront(tNode);
        }
        else
        {
            //No node was found, create a new one
            tNode = new BDQueueNode<T>();

            //Set the node
            tNode.SetData(_data);

            //Add it to the Active list
            AddFront(tNode);
        }
    }

    public void EnqueueBack(T _data)
    {
        BDQueueNode<T> tNode = PopReserve();

        if (tNode != null)
        {
            //Set node
            tNode.SetData(_data);

            //Add to list
            AddBack(tNode);
        }
        else
        {
            //No node was found, create a new one
            tNode = new BDQueueNode<T>();

            //Set the node
            tNode.SetData(_data);

            //Add it to the Active list
            AddBack(tNode);
        }
    }
    //Return and eliminate the Front data
    public T PopFront()
    {
        T result = PeekFront();

        if (!result.Equals(default(T)))
        {
            //Remove it from the active list and move it to reserve
            AddReserve(RemoveFront());
        }

        return result;
    }
    //Return and eliminate the Tail data
    public T PopBack()
    {
        T result = PeekBack();

        if (!result.Equals(default(T)))
        {
            //Remove it from the active list and move it to reserve
            AddReserve(RemoveBack());
        }

        return result;
    }

    //Get size of the active list
    public int GetSize()
    {
        int tSize = 0;

        pIterator.SetStartNode(pActiveTail);

        while (pIterator.GetNode() != null)
        {
            //Count up
            tSize += 1;

            //Keep walking Johnny
            pIterator.GoNext();
        }

        return tSize;
    }

    //Clear function resets the Active list, and returns all nodes to Reserve
    public void ClearQueue()
    {
        //Walk the list and clear the queue
        pActiveHead = null;
        pActiveTail = null;
    }
}
