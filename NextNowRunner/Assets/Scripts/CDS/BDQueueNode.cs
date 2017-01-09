using UnityEngine;
using System.Collections;

public class BDQueueNode<T>
{

    BDQueueNode<T> pNext;
    T myData;

    public BDQueueNode()
    {
        pNext = null;
        myData = default(T);
    }

    public void SetNext(BDQueueNode<T> _next)
    {
        pNext = _next;
    }

    public BDQueueNode<T> GetNext()
    {
        return pNext;
    }

    public void SetData(T _data)
    {
        myData = _data;
    }

    public T GetData()
    {
        return myData;
    }

}
