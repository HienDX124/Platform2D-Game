using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyMoveController moveController;
    [SerializeField] private Vector3[] movePath;

    private void Start()
    {
        StartMove(movePath);
    }

    public void StartMove(Vector3[] path)
    {
        moveController.SetUpMovePath(path);
    }

    public void StopMove()
    {
        moveController.StopMove();
    }
}
