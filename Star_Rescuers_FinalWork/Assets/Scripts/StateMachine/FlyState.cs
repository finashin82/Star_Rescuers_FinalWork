using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : State
{
    private Player _player;

    public FlyState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Вход в состояние полета");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Выход из состояния полета");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Я лечу");

        _player.RB.AddForce(Vector2.up * _player.FlyForce, ForceMode2D.Force);
    }
}
