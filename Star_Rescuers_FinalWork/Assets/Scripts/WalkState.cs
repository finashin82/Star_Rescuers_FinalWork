using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    private Player _player;

    public WalkState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Вход в состояние ходьбы");

        _player.AnimatorPlayer.SetBool("isRun", true);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Выход из состояния ходьбы");

        _player.AnimatorPlayer.SetBool("isRun", false);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Я иду");

        
    }
}
