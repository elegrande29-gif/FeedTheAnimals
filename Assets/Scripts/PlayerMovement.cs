/*

Component: PlayerMovement

Attached to: Player GameObject

Purpose: Handles player horizontal movement within defined boundary constraints and drives movement animation.
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
[SerializeField] protected float playerSpeed;
private float centerToEdge = 22.0f;
private bool directionXPositive;

private Vector2 moveInput;
private Animator animator;

private void Start()
{
    animator = GetComponent<Animator>();
}

private void Update()
{
    Move();
}

// Called by: Player Input / Animator
public void OnMovementInput(InputAction.CallbackContext ctx)
{
    moveInput = ctx.ReadValue<Vector2>();
    DeterminePlayerDirection(moveInput);
}

private void DeterminePlayerDirection(Vector2 xValue)
{
    if (xValue.x > 0)
    {
        directionXPositive = true;
    }
    else if (xValue.x < 0)
    {
        directionXPositive = false;
    }
}

private void Move()
{
    if (moveInput.x != 0)
    {
        float targetX = transform.position.x + moveInput.x * playerSpeed * Time.deltaTime;
        targetX = Mathf.Clamp(targetX, -centerToEdge, centerToEdge);

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

        if (animator != null)
        {
            animator.SetBool("IsRunning", true);
        }
    }
    else
    {
        if (animator != null)
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
}
