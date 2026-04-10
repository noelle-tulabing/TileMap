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
        if (IsNotUsingPriorityInputDevice(inputDevice))
        {
            return;
        }
        faceCorrectionDirection(direction);
        applyMovement(direction);
        Animate(direction);
    }

    private bool IsNotUsingPriorityInputDevice(object inputDevice)
    {
        return inputDevice != priorityDevice;
    }

    private void faceCorrectionDirection(Vector2 direction)
    {
        if (isNotFacingCorrectDirectin(direction))
        {
            flipFacingDirection();
        }
    }

    private void flipFacingDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private bool isNotFacingCorrectDirectin(Vector2 direction)
    {
        return direction.x > 0 && transform.localScale.x < 0 || direction.x < 0 && transform.localScale.x > 0;
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

    private void Animate(Vector2 direction)
    {
        Animator.SetFloat("Horizontal", Mathf.Abs(direction.x));
        Animator.SetFloat("Vertical", Mathf.Abs(direction.y));
    }
}
