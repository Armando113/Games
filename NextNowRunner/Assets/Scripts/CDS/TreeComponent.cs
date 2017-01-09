using UnityEngine;
using System.Collections;

abstract public class TreeComponent : NodeLink
{

    protected TreeComponent pActiveHead;
    protected TreeComponent pReserveHead;
    protected TreeIterator pIterator;

    protected TreeComponent(BaseType _type) : base(_type)
    {
        pIterator = new TreeIterator();
    }

    //These will be our internal methods 
    protected virtual TreeComponent AddActiveChild(TreeComponent _node)
    {
        //Do nothing
        return null;
    }

    protected virtual TreeComponent AddReserveChild(TreeComponent _node)
    {
        //Do nothing
        return null;
    }

    protected virtual TreeComponent RemoveActiveChild(TreeComponent _node)
    {
        //Do nothing
        return null;
    }

    protected virtual TreeComponent PopReserveChild()
    {
        //Do nothing 
        return null;
    }

    public virtual bool Contains(TreeComponent _node)
    {
        return false;
    }

    //Get an object from your tree
    public virtual TreeComponent GetObject()
    {
        return null;
    }

    protected virtual TreeComponent FindActive(TreeComponent _object)
    {
        return null;
    }

    public virtual void ReturnObject(TreeComponent _object)
    {
        //Do nothing
    }

    //Public virtual Methods
    public virtual void ActivateObject()
    {
        //Do nothing
    }

    public virtual void DeactivateObject()
    {
        //Do Nothing
    }
}
