using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : State
{
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
    }
}
