using UnityEngine;
using System.Collections;

public class EndObserver : Observer
{

    private GameController parentCtrl;

    public EndObserver(GameController _parent)
    {
        parentCtrl = _parent;
    }

    public override void Update()
    {
        parentCtrl.mPlayer = null;
    }
}
