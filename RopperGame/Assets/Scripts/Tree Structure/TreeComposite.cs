using UnityEngine;
using System.Collections;

abstract public class TreeComposite : TreeComponent
{

    protected TreeComposite(GameObjectType _type) : base(_type)
    {

    }

    protected override TreeComponent AddActiveChild(TreeComponent _node)
    {
        //Let's check if the node is NOT null
        if (_node != null)
        {
            //It's not null, let's add it!!

            //Case 1: The active list is empty
            if (pActiveChildHead == null)
            {
                //Head points to new node
                pActiveChildHead = _node;
            }
            //Case 2: The list is not empty
            else
            {
                //Add it to the front
                //Step 1: Point head's Prev to new node
                pActiveChildHead.SetPrev(_node);
                //Step 2: Point new node's next to head
                _node.SetNext(pActiveChildHead);
                //Step 3: Head is now new node
                pActiveChildHead = _node;
            }
        }
        return _node;
    }

    protected override TreeComponent AddReserveChild(TreeComponent _node)
    {
        //Let's check if the node is NOT null
        if (_node != null)
        {
            //It's not null, let's add it!!

            //Case 1: The active list is empty
            if (pReserveChildHead == null)
            {
                //Head points to new node
                pReserveChildHead = _node;
            }
            //Case 2: The list is not empty
            else
            {
                //Add it to the front
                //Step 1: Point head's Prev to new node
                pReserveChildHead.SetPrev(_node);
                //Step 2: Point new node's next to head
                _node.SetNext(pReserveChildHead);
                //Step 3: Head is now new node
                pReserveChildHead = _node;
            }

        }

        return _node;
    }

    protected override TreeComponent FindActive(TreeComponent _node)
    {
        //Set the iterator's first node
        pIterator.SetStartNode(pActiveChildHead);

        //Let the iterator walk the list
        while (pIterator.GetNode() != null)
        {
            //Is this the node we're looking for?
            if (_node == pIterator.GetNode())
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

    protected override TreeComponent PopReserveChild()
    {
        //Create the result node
        TreeComponent tResult = pReserveChildHead;

        //Check if there are nodes in the reserve list
        if (tResult != null)
        {
            //Case 1: There is only One node Left
            if (tResult.GetNext() == null)
            {
                //Head points to null
                pReserveChildHead = null;
            }
            //Case 2: There are more nodes in the list
            else
            {
                //Step 1: Move the head to the next node
                pReserveChildHead = (TreeComponent)tResult.GetNext();
                //Step 2: Remove the nodes next
                tResult.SetNext(null);
                //Step 3: Remove the head's previous
                pReserveChildHead.SetPrev(null);
            }
        }

        return tResult;
    }

    protected override TreeComponent RemoveActive(TreeComponent _node)
    {
        //Is the node not null?
        if (_node != null)
        {
            //We assume the node is in the list, no need to look for it
            //Case 1: It's the last node in the list
            if (_node == pActiveChildHead && _node.GetNext() == null)
            {
                //Remove the head
                pActiveChildHead = null;
            }
            //Case 2: It's the head, but not the last
            else if (_node == pActiveChildHead)
            {
                //Step 1: Pass head to the next
                pActiveChildHead = (TreeComponent)_node.GetNext();
                //Step 2: Remove nodes next
                _node.SetNext(null);
                //Step 3: Remove the head its prev
                pActiveChildHead.SetPrev(null);
            }
            //Case 3: Is the node is somewhere in this list
            else
            {
                //Step 1: Remove next, and relink the next's Prev
                if (_node.GetNext() != null)
                {
                    _node.GetNext().SetPrev(_node.GetPrev());
                }

                //Step 2: Remove prev, and relink 
                if (_node.GetPrev() != null)
                {
                    _node.GetPrev().SetNext(_node.GetNext());
                }

                //Step 3: Remove our next and prev
                _node.SetNext(null);
                _node.SetPrev(null);
            }

        }

        return _node;
    }

    public override TreeComponent LoanObject()
    {

        TreeLeaf tResult = (TreeLeaf)PopReserveChild();

        if(tResult != null)
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
        if(_object != null)
        {
            //Check if we have this object
            if (_object == FindActive(_object))
            {
                //Deactivate the object
                _object.gameObject.SetActive(false);

                //Return to zero position
                _object.transform.position = Vector3.zero;

                //Remove from active
                RemoveActive(_object);

                //Add to reserve
                AddReserveChild(_object);
            }
        }
    }
}
