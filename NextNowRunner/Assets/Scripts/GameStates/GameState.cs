using UnityEngine;
using System.Collections;

abstract public class GameState
{
    protected GameState()
    {

    }

    abstract public void Enter();

    abstract public void Execute();

    abstract public void Exit();
}
