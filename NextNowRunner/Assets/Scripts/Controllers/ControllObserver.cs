using UnityEngine;
using System.Collections;
using System;

public class ControllObserver : Observer
{

    private GameController parentCtrl;

    public ControllObserver(GameController _parent)
    {
        parentCtrl = _parent;
    }

    public override void Update()
    {
        parentCtrl.mPlayer = PlayerFactory.GetPlayerReference();
    }
}
