using System.Collections;
using System.Collections.Generic;
using LTA.BasicCharacter.Character2D.Platform;
using UnityEngine;

public class EnemyMoveController : Character2DPlatformMoveController
{
    public bool isMoving { get; private set; }
    [SerializeField] private Transform bodyTransform;
    private Vector3[] currentPath;
    private int currentPathNodeIndex;
    private int totalNode;
    private Vector3 nextTarget;
    [SerializeField] private MoveLoopType loopType;

    public void Move(Vector3 dir)
    {
        this.Direction = dir;
        isMoving = true;
    }

    public void MoveToPos(Vector3 target)
    {
        bodyTransform.position = Vector3.MoveTowards(bodyTransform.position, nextTarget, MoveController.speed * Time.deltaTime);
    }

    public void StopMove()
    {
        this.Direction = Vector3.zero;
        isMoving = false;
    }

    public void SetUpMovePath(Vector3[] path)
    {
        currentPath = path;
        totalNode = path.Length;
        isMoving = true;
        currentPathNodeIndex = 0;
        nextTarget = currentPath[currentPathNodeIndex];
    }

    public void UpdateNodePath()
    {
        currentPathNodeIndex += 1;
        if (totalNode <= currentPathNodeIndex)
        {
            ReversePath();
            return;
        }

        nextTarget = currentPath[currentPathNodeIndex];
    }

    private void ReversePath()
    {
        Vector3[] newPath = new Vector3[totalNode];

        switch (loopType)
        {
            case MoveLoopType.Closed:
                currentPathNodeIndex = -1;
                break;
            case MoveLoopType.Restart:

                currentPathNodeIndex = 0;
                nextTarget = currentPath[1];
                bodyTransform.position = currentPath[0];

                break;
            case MoveLoopType.Yoyo:
                for (int i = 0; i < totalNode; i++)
                {
                    newPath[i] = currentPath[totalNode - i - 1];
                }
                currentPathNodeIndex = -1;
                currentPath = newPath;
                break;
            case MoveLoopType.YoyoClosed:
                for (int i = 0; i < totalNode; i++)
                {
                    newPath[i] = currentPath[totalNode - i - 1];
                }
                currentPathNodeIndex = -1;
                currentPath = newPath;
                nextTarget = currentPath[totalNode - 1];
                break;
        }
    }

    private void Update()
    {
        if (!isMoving) return;
        if (currentPath == null || totalNode <= 0) return;

        MoveToPos(nextTarget);

        if (bodyTransform.position == nextTarget)
        {
            UpdateNodePath();
        }
    }
}

public enum MoveLoopType
{
    Closed,
    Restart,
    Yoyo,
    YoyoClosed
}