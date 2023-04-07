using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMoveController moveController;
    [SerializeField] private Transform tranShoot;
    private int count = 0;
    private void Update()
    {
        count++;
        if (Input.GetKey(KeyCode.D))
        {
            moveController.Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveController.Move(Vector3.left);
        }

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