using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        // Ќаправление по горизонтальной оси (Input.GetAxisRaw - направление: возвращает точные значени€ -1, 0, 1)
        // Ќаправление по горизонтальной оси (Input.GetAxis - направление: возвращает промежуточные значени€ от -1 до 1)        
        float horizontalDirection = Input.GetAxis(GlobalStringVars._horizontalAxis);
        
        // ѕровер€ем нажата или нет клавиша прыжка
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars._jumpButton);

        if (Input.GetButtonDown(GlobalStringVars._fire1))
        {
            shooter.Shoot(horizontalDirection);
        }

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
