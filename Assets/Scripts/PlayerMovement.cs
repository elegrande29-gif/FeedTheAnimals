using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    protected float playerSpeed = 5.0f;
    private float centerToEdge = 22.0f;
    private Vector2 movementDirection;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void OnMovementInput(InputAction.CallbackContext ctx)
    {
        movementDirection = ctx.ReadValue<Vector2>();
    }

    private void Move()
    {
        // Move the player based on horizontal input along the X-axis
        transform.Translate(Vector3.right * movementDirection.x * playerSpeed * Time.deltaTime);

        // Keep the player within the horizontal boundaries defined by centerToEdge
        float clampedX = Mathf.Clamp(transform.position.x, -centerToEdge, centerToEdge);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Update animator parameter if an Animator component is attached
        if (animator != null)
        {
            animator.SetBool("IsRunning", movementDirection.x != 0);
        }
    }
}