using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Player _player;

    public IdleState (Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Вход в состояние покоя");        
    }

    public override void Exit() 
    { 
        base.Exit();
        Debug.Log("Выход из состояния покоя ");
    }
}
