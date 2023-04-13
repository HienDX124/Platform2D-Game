using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMoveController moveController;
    [SerializeField] private CharacterJumpController jumpController;

    [SerializeField] private Transform tranShoot;
    [SerializeField] private JoyStickContoller joystick;
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private ButtonController buttonController;

    private Vector3 direction;

    private void Start()
    {
        buttonController.doSomething = Shooting;
    }

    private void Update()
    {
        direction = new Vector3(joystick.Direction.x, 0);
        moveController.Move(direction);

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            moveController.StopMove();
        }

        if (joystick.Direction.y > 0.7f)
        {
            jumpController.Jump();
        }
    }

    private void Shooting()
    {
        shootingController.Shooting(tranShoot);
    }
}