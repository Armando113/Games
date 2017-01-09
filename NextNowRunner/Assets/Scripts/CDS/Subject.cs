using UnityEngine;
using System.Collections;

abstract public class Subject
{
    //A list of our observers
    protected DLL<Observer> myObservers;

    public abstract void RegisterObserver(Observer _o);

    public abstract void RemoveObserver(Observer _o);

    public abstract void NotifyObservers();

}
