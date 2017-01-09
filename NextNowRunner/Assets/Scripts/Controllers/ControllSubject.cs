using UnityEngine;
using System.Collections;
using System;

public class ControllSubject : Subject
{

    public ControllSubject()
    {
        myObservers = new DLL<Observer>();
    }

    public override void NotifyObservers()
    {
        for(int i = 0; i < myObservers.GetSize(); i++)
        {
            myObservers[i].Update();
        }
    }

    public override void RegisterObserver(Observer _o)
    {
        myObservers.Add(_o);
    }

    public override void RemoveObserver(Observer _o)
    {
        myObservers.Remove(_o);
    }
}
