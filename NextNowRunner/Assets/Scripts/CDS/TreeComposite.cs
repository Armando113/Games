using UnityEngine;
using System.Collections;

abstract public class TreeComposite : TreeComponent
{

    protected TreeComposite(BaseType _type) : base(_type)
    {

    }

    protected override TreeComponent AddActiveChild(TreeComponent _node)
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

    protected override TreeComponent AddReserveChild(TreeComponent _node)
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

    protected override TreeComponent RemoveActiveChild(TreeComponent _node)
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
                pActiveHead = (TreeComponent)_node.GetNext();
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

    protected override TreeComponent PopReserveChild()
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
                pReserveHead = (TreeComponent)tResult.GetNext();
                //Detach from the node
                pReserveHead.SetPrev(null);
                //Detach from the head
                tResult.SetNext(null);
            }

            return (TreeComponent)tResult;
        }
        //the list is empty, return null
        return null;
    }

    protected override TreeComponent FindActive(TreeComponent _object)
    {
        //is it null?
        if(_object == null)
        {
            return null;
        }
        //Set the iterator's first node
        pIterator.SetNode(pActiveHead);

        //Let the iterator walk the list
        while (pIterator.GetNode() != null)
        {
            //Is this the node we're looking for?
            if (_object == pIterator.GetNode())
            {
                //We found it!!
                return pIterator.GetNode();
            }

            //We didn't find it
            //Keep walking Johnny
            pIterator.GoNext();
        }

        //In case everything goes to hell, return null
        return null;
    }

    public override bool Contains(TreeComponent _node)
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

    public override TreeComponent GetObject()
    {
        TreeLeaf tResult = (TreeLeaf)PopReserveChild();

        if (tResult != null)
        {
            //Activate object
            tResult.gameObject.SetActive(true);
            
            //Add to active
            AddActiveChild(tResult);
        }

        return tResult;
    }

    public override void ReturnObject(TreeComponent _object)
    {
        //Put the used object back to reserve
        if(FindActive(_object) == _object)
        {
            //Deactivate object
            _object.gameObject.SetActive(false);

            //Remove from Active
            RemoveActiveChild(_object);

            //Add to reserve
            AddReserveChild(_object);
        }
    }
}
