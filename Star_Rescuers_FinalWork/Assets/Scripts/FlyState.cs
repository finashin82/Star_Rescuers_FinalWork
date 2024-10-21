using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : State
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("���� � ��������� ������");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("����� �� ��������� ������");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("� ����");
    }
}
