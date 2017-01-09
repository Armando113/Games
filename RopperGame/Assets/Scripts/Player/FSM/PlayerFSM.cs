using UnityEngine;
using System.Collections;

public class PlayerFSM : FSM
{
    private static PlayerFSM pInstance;

    //Our controllers
    private PlayerCtrlMode mCurrCtrl;
    private MenuCtrl mMenuCtrl;
    private GameCtrl mGameCtrl;
    private GameOverCtrl mGameOverCtrl;

    private PlayerFSM() : base(null)
    {

        mMenuCtrl = new MenuCtrl();
        mGameCtrl = new GameCtrl();
        mGameOverCtrl = new GameOverCtrl();

        mCurrCtrl = mMenuCtrl;
        mGameCtrl.Activate();
    }

    private static PlayerFSM GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new PlayerFSM();
        }
        return pInstance;
    }

    //The types of commands the player can give
    public static void OnTap(KeyCode _keyCode)
    {
        GetInstance().mCurrCtrl.OnTap(_keyCode);
    }
    public static void OnTap(Touch _touch)
    {
        GetInstance().mCurrCtrl.OnTap(_touch);
    }

    public static void SetMenuCtrl()
    {
        GetInstance().SwitchCtrls(GetInstance().mMenuCtrl);
    }

    public static void SetGameCtrl()
    {
        GetInstance().SwitchCtrls(GetInstance().mGameCtrl);
    }

    public static void SetGameOverCtrl()
    {
        GetInstance().SwitchCtrls(GetInstance().mGameOverCtrl);
    }

    private void SwitchCtrls(PlayerCtrlMode _newCtrl)
    {
        if(_newCtrl != null)
        {
            GetInstance().mCurrCtrl.Terminate();

            GetInstance().mCurrCtrl = _newCtrl;

            GetInstance().mCurrCtrl.Activate();
        }
    }

    public static PlayerCtrlMode GetCurrentCtrlMode()
    {
        return GetInstance().mCurrCtrl;
    }

}
