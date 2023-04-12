using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMoveController moveController;
    [SerializeField] private Transform tranShoot;
    [SerializeField] private JoyStickContoller joystick;
    private int count = 0;
    private Vector3 direction;
    private void Update()
    {
        count++;
        direction = new Vector3(joystick.Direction.x,0);
        moveController.Move(direction);
        
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            moveController.StopMove();
        }
        
        if (Input.GetKey(KeyCode.Space) && count > 300)
        {
            Shooting();
            count = 0;
        }
    }

    protected void Shooting()
    {
        Creator.Instance.CreateBulletPref(tranShoot);
    }
}