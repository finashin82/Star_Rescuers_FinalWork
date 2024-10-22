using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{ 
    public State CurrentState { get; set; }

    /// <summary>
    /// Первое состояние, в которое входит игрок при запуске игры
    /// </summary>
    /// <param name="startState"></param>
    public void Initialize (State startState)
    {
        // Записываем текущее состояние
        CurrentState = startState;

        // Входим в текущее состояние
        CurrentState.Enter();
    }

    /// <summary>
    /// Смена состояния
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
    {
        // Выход из текущего состояния
        CurrentState.Exit();

        // Изменяем текущее состояние
        CurrentState = newState;

        // Входим в текущее состояние
        CurrentState.Enter();
    }
}
