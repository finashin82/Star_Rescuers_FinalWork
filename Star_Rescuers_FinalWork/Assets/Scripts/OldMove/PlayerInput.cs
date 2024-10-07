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
        // ����������� �� �������������� ��� (Input.GetAxisRaw - �����������: ���������� ������ �������� -1, 0, 1)
        // ����������� �� �������������� ��� (Input.GetAxis - �����������: ���������� ������������� �������� �� -1 �� 1)        
        float horizontalDirection = Input.GetAxis(GlobalStringVars._horizontalAxis);
        
        // ��������� ������ ��� ��� ������� ������
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars._jumpButton);

        if (Input.GetButtonDown(GlobalStringVars._fire1))
        {
            shooter.Shoot(horizontalDirection);
        }

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
