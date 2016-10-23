using UnityEngine;
using System.Collections;

public abstract class PlayerCtrlMode
{

    //Type of Controller
    protected CtrlType mCtrlType;

    public PlayerCtrlMode(CtrlType _mCtrlType)
    {
        mCtrlType = _mCtrlType;
    }
	
    public CtrlType GetCtrlType()
    {
        return mCtrlType;
    }

    //Virtual Functions
    public virtual void Activate()
    {

    }

    public virtual void Terminate()
    {

    }

    //Abstract functions that MUST be implemented in the code
    /// <summary>
    /// Our behaviours when a tap is registered
    /// </summary>
    /// <param name="_keyCode"></param>
    public abstract void OnTap(KeyCode _keyCode);

    public abstract void OnTap(Touch _touch);
}
