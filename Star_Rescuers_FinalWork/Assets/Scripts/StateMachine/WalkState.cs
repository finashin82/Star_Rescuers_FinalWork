using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

        //_player.AnimatorPlayer.SetBool("isRun", true);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Выход из состояния ходьбы");

        //_player.AnimatorPlayer.SetBool("isRun", false);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Я иду");

        _player.RB.velocity = new Vector2(_player.MoveVector.x * _player.SpeedPlayer, _player.RB.velocity.y);

        // Поворот спрайта в зависимости от условий
        if (_player.MoveVector.x > 0)
        {
            LeftOrRigth(1);
        }
        else if (_player.MoveVector.x < 0)
        {
            LeftOrRigth(-1);
        }

        // Поворот спрайта
        void LeftOrRigth(int leftOrRigth)
        {
            _player.transform.localScale = new Vector2(leftOrRigth, 1);
        }
    }
}
