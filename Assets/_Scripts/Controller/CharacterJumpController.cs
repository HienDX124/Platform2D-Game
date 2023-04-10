using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mainBody;
    [SerializeField] private float jumpForce;
    public bool IsJumping { get; protected set; }

    public void Jump()
    {
        if (IsJumping) return;
        IsJumping = true;

        mainBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Landed();
        }
    }

    public void Landed()
    {
        IsJumping = false;
    }
}
