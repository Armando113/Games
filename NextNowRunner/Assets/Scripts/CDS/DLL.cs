using UnityEngine;
using System.Collections;

public class DLL<T>
{

    //Variables
    DLLNode<T> pActiveHead;
    DLLNode<T> pReserveHead;
    DLLIterator<T> pIterator;

    public DLL()
    {
        pActiveHead = null;
        pReserveHead = null;
        pIterator = new DLLIterator<T>();
    }

    //Overload operator
    public T this[int _index]
    {
        get
        {
            return GetAt(_index);
        }

        set
        {
            //No set for now
        }
    }

    protected void ClearActive()
    {
        //Make sure that there are active nodes
        if (pActiveHead != null)
        {
            //Set the iterator
            pIterator.SetNode(pActiveHead);

            //Walk through the list and send them to reserve
            while (pIterator.GetNode() != null)
            {
                //Get the node in a temp
                DLLNode<T> tNode = pIterator.GetNode();

                //Advance to the next node
                pIterator.GoNext();

                //Erase the node and send it to reserve
                RemoveActive(tNode);
                AddReserve(tNode);
            }
        }
    }

    //Interal methods
    protected DLLNode<T> AddActive(DLLNode<T> _node)
    {
        //Check that we have a valid node
        if(_node != null)
        {
            //Case 1: The list is empty
            if(pActiveHead == null)
            {
                //Active head is now the Node
                pActiveHead = _node;
            }
            //Case 2: There are other nodes in the List
            else
            {
                //Attach node to head
                _node.SetNext(pActiveHead);
                //Attach head to node
                pActiveHead.SetPrev(_node);
                //Move the head
                pActiveHead = _node;
            }
        }

        return _node;
    }

    protected DLLNode<T> AddReserve(DLLNode<T> _node)
    {
        //Check that we have a valid node
        if (_node != null)
        {
            //Case 1: The list is empty
            if (pReserveHead == null)
            {
                //Active head is now the Node
                pReserveHead = _node;
            }
            //Case 2: There are other nodes in the List
            else
            {
                //Attach node to head
                _node.SetNext(pReserveHead);
                //Attach head to node
                pReserveHead.SetPrev(_node);
                //Move the head
                pReserveHead = _node;
            }
        }

        return _node;
    }
	
    protected DLLNode<T> RemoveActive(DLLNode<T> _node)
    {
        //We assume that the node is in the list
        //Safety check
        if(_node != null)
        {
            //Case 1: The node is the last one in the list
            if (pActiveHead == _node && _node.GetNext() == null)
            {
                //The head now points to null
                pActiveHead = null;
            }
            //Case 2: It's the Head, but there are more nodes
            else if(pActiveHead == _node)
            {
                //Move the head
                pActiveHead = _node.GetNext();
                //Detach the node
                _node.SetNext(null);
                //Detach the head
                pActiveHead.SetPrev(null);
            }
            //Case 3: Th node is lost somewhere in the list
            else
            {
                //Detach from it's next
                if(_node.GetNext() != null)
                {
                    _node.GetNext().SetPrev(_node.GetPrev());
                }

                if(_node.GetPrev() != null)
                {
                    _node.GetPrev().SetNext(_node.GetNext());
                }

                //Completely detach the node
                _node.SetNext(null);
                _node.SetPrev(null);
            }
        }

        return _node;
    }

    protected DLLNode<T> PopReserve()
    {
        //Check that the list isn't empty
        if(pReserveHead != null)
        {
            DLLNode<T> tResult = pReserveHead;

            //Case 1: It's the last node
            if(pReserveHead.GetNext() == null)
            {
                pReserveHead = null;
            }
            //Case 2: There are more nodes left
            else
            {
                //Move the head
                pReserveHead = tResult.GetNext();
                //Detach from the node
                pReserveHead.SetPrev(null);
                //Detach from the head
                tResult.SetNext(null);
            }

            return tResult;
        }
        //the list is empty, return null
        return null;
    }

    protected DLLNode<T> Find(T _data)
    {
        //is the data not null?
        if(_data != null)
        {
            //Set our iterator to the active
            pIterator.SetNode(pActiveHead);

            //Walk the list, and find that Node!!
            while(pIterator.GetNode() != null)
            {

                //Check if this is the node we are looking for
                if(pIterator.GetNode().GetData().Equals(_data))
                {
                    //We found it!!
                    return pIterator.GetNode();
                }
                //Keep walking Johnny
                pIterator.GoNext();
            }
        }

        return null;
    }

    //Public methods
    public bool Contains(T _node)
    {
        //Set the Iterator
        pIterator.SetNode(pActiveHead);

        //Walk the list and see if you can find it
        while(pIterator.GetNode() != null)
        {
            //Is this the one?
            if (_node.Equals(pIterator.GetNode().GetData()))
            {
                //Yes, yes it is!! :)
                return true;
            }

            //Keep walking Johnny
            pIterator.GoNext();
        }

        //We couldn't find the node
        return false;
    }

    public void Add(T _data)
    {
        //Get a node from reserve
        DLLNode<T> tNode = PopReserve();
        //Do we need a new Node?
        if(tNode == null)
        {
            //Yes, yes we do
            tNode = new DLLNode<T>(_data);
        }
        else
        {
            //No we don't, just set the data :)
            tNode.SetData(_data);
        }

        //Add it to the Active list
        AddActive(tNode);
    }

    public void Remove(T _data)
    {
        //Find the data first
        DLLNode<T> tNode = Find(_data);

        //Did we find it?
        if(tNode != null)
        {
            //Yep, let's take it out!
            RemoveActive(tNode);

            //Add it to the reserve
            AddReserve(tNode);
        }
    }

    //Get the first Active data in the list
    public T Peek()
    {
        if(pActiveHead != null)
        {
            return pActiveHead.GetData();
        }
        return default(T);
    }

    public T GetAt(int _index)
    {
        pIterator.SetNode(pActiveHead);

        int counter = 0;

        while(pIterator.GetNode() != null)
        {
            if(counter == _index)
            {
                //We found it!
                return pIterator.GetNode().GetData();
            }

            //Count up
            counter++;

            //Keep walking Johnny
            pIterator.GoNext();
        }

        return default(T);
    }

    public int GetSize()
    {
        int tSize = 0;

        pIterator.SetNode(pActiveHead);

        while(pIterator.GetNode() != null)
        {
            //Count up
            tSize += 1;

            //Keep walking Johnny
            pIterator.GoNext();
        }

        return tSize;
    }

    //Clear the active list and send all nodes to reserve
    public void Clear()
    {
        ClearActive();
    }

}
