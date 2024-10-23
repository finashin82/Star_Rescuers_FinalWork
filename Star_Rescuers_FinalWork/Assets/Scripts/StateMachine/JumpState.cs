using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private Player _player;

    public JumpState(Player player)
    {
        _player = player;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Вход в состояние прыжка");

        //_player.AnimatorPlayer.SetBool("isJump", true);

        _player.RB.AddForce(Vector2.up * _player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Выход из состояния прыжка");

        //_player.AnimatorPlayer.SetBool("isJump", false);
    }
}
