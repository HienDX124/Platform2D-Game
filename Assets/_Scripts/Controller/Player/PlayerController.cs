using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMoveController moveController;

    private void Update()
    {
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
    }
}