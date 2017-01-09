using UnityEngine;
using System.Collections;

public class NodeLink : MonoBehaviour
{

    //Variables
    protected NodeLink pNext;
    protected NodeLink pPrev;

    //This HAS to be public! We have no choice :(  
    //I don't like this, but it seems we have no choice for the GameObject
    //public GameObject myGameObject;

    protected BaseType myType;

    protected NodeLink(BaseType _type)
    {
        myType = _type;
    }

    public NodeLink GetNext()
    {
        return pNext;
    }

    public void SetNext(NodeLink _next)
    {
        pNext = _next;
    }

    public NodeLink GetPrev()
    {
        return pPrev;
    }

    public void SetPrev(NodeLink _prev)
    {
        pPrev = _prev;
    }

    public BaseType GetBaseType()
    {
        return myType;
    }
}
