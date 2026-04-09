using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = GameParameters.PlayerSpeed;
    public Rigidbody2D Rigidbody2D;
    public Animator Animator;

    private object priorityDevice = null;

    public void Move(Vector2 direction, object inputDevice)
    {
        setPriorityInputDevice(direction, inputDevice);
        applyMovement(direction);
    }

    private void setPriorityInputDevice(Vector2 direction, object inputDevice)
    {
        if (IsMoving(direction))
        {
            priorityDevice = inputDevice;
        }
    }

    private bool IsMoving(Vector2 direction)
    {
        return direction != Vector2.zero; // checks both x & y if they're 0
    }

    private void applyMovement(Vector2 direction) // using physics engine to apply force to move sprite
    {
        Rigidbody2D.linearVelocity = direction * Speed;
    }
}
