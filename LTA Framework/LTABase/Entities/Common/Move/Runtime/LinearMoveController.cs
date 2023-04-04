using UnityEngine;
namespace LTA.Move
{
    [DisallowMultipleComponent]
    public class LinearMoveController : MoveController
    {
        public override void Move(Vector3 direction)
        {
            if (isStop) return;
            this.direction = direction;
            transform.position += this.direction * speed * Time.fixedDeltaTime;
        }

    }
}
