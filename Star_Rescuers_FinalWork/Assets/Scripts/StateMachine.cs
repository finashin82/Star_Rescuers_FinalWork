using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{ 
    public State CurrentState { get; set; }

    /// <summary>
    /// ������ ���������, � ������� ������ ����� ��� ������� ����
    /// </summary>
    /// <param name="startState"></param>
    public void Initialize (State startState)
    {
        // ���������� ������� ���������
        CurrentState = startState;

        // ������ � ������� ���������
        CurrentState.Enter();
    }

    /// <summary>
    /// ����� ���������
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
    {
        // ����� �� �������� ���������
        CurrentState.Exit();

        // �������� ������� ���������
        CurrentState = newState;

        // ������ � ������� ���������
        CurrentState.Enter();
    }
}
