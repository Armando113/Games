using UnityEngine;
using System.Collections;

public class DLLNode<T>
{

    //Variables
    private DLLNode<T> pNext;
    private DLLNode<T> pPrev;

    private T data;

	public DLLNode(T _data)
    {
        data = _data;
    }

    public DLLNode<T> GetNext()
    {
        return pNext;
    }

    public void SetNext(DLLNode<T> _next)
    {
        pNext = _next;
    }

    public DLLNode<T> GetPrev()
    {
        return pPrev;
    }

    public void SetPrev(DLLNode<T> _prev)
    {
        pPrev = _prev;
    }

    public void SetData(T _data)
    {
        data = _data;
    }
    public T GetData()
    {
        return data;
    }

}
