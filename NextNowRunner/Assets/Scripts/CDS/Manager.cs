using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Manager
{
    //Variables
    protected NodeLink pActiveHead;
    protected NodeLink pReserveHead;
    protected NodeIterator pIterator;

    protected Manager()
    {
        pActiveHead = null;
        pReserveHead = null;
        pIterator = new NodeIterator();
    }

    protected NodeLink AddActive(NodeLink _node)
    {
        //Check that we have a valid node
        if (_node != null)
        {
            //Case 1: The list is empty
            if (pActiveHead == null)
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

    protected NodeLink AddReserve(NodeLink _node)
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

    protected NodeLink RemoveActive(NodeLink _node)
    {
        //We assume that the node is in the list
        //Safety check
        if (_node != null)
        {
            //Case 1: The node is the last one in the list
            if (pActiveHead == _node && _node.GetNext() == null)
            {
                //The head now points to null
                pActiveHead = null;
            }
            //Case 2: It's the Head, but there are more nodes
            else if (pActiveHead == _node)
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
                if (_node.GetNext() != null)
                {
                    _node.GetNext().SetPrev(_node.GetPrev());
                }

                if (_node.GetPrev() != null)
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

    protected NodeLink PopReserve()
    {
        //Check that the list isn't empty
        if (pReserveHead != null)
        {
            NodeLink tResult = pReserveHead;

            //Case 1: It's the last node
            if (pReserveHead.GetNext() == null)
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

    public bool Contains(NodeLink _node)
    {
        //Set the Iterator
        pIterator.SetNode(pActiveHead);

        //Walk the list and see if you can find it
        while (pIterator.GetNode() != null)
        {
            //Is this the one?
            if (pIterator.GetNode() == _node)
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

    public void DumpActiveNodes()
    {
        pIterator.SetNode(pActiveHead);

        int counter = 0;
        
        while(pIterator.GetNode() != null)
        {
            counter++;

            pIterator.GoNext();
        }

        Debug.Log("No. of Active nodes: " + counter.ToString());
    }
}
