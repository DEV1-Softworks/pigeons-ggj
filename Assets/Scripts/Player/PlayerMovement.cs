using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    private PlayerActions playerActions;
    private Rigidbody2D rb2D;
    private Vector2 moveDirection;

    private PlayerAnimations playerAnimations;
    private float jumpingPower = 16f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context.canceled);

        if (context.performed && IsGrounded())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpingPower);
        }

        if (context.canceled && rb2D.velocity.y > 0f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Move()
    {
        rb2D.MovePosition(rb2D.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void ReadMovement()
    {
        moveDirection = playerActions.Movement.Move.ReadValue<Vector2>().normalized;

        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMoveBoolTransition(false);
            return;
        }

        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }

}