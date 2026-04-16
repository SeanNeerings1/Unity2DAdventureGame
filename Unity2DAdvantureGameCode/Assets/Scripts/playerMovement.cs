using UnityEngine;
using UnityEngine.InputSystem;

// This script handles player movement, jumping, and sprinting
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement settings")]

    // Movement speed (editable in Inspector with range slider)
    [Range(1, 10)]
    [SerializeField] private float _speed = 5f;

    // Stores the original speed (used for sprint reset)
    private float _baseSpeed;

    [Header("Player setup")]

    // Reference to the PlayerInput script (handles input events)
    [SerializeField] private PlayerInput _playerInput;

    // Force applied when jumping
    [SerializeField] private float _jumpForce = 7f;

    // Rigidbody2D reference for physics-based movement
    private Rigidbody2D _rb;

    // Tracks whether the player is touching the ground
    private bool grounded;

    // Stores the current movement input
    private Vector2 _currentInput;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the player
        _rb = GetComponent<Rigidbody2D>();

        // Save the base movement speed
        _baseSpeed = _speed;

        // Subscribe to input events from PlayerInput script
        _playerInput.OnInputReceived.AddListener(PlayerMove);
        _playerInput.OnJumpReceived.AddListener(Jump);
    }

    // Called when movement input is received
    private void PlayerMove(Vector2 direction)
    {
        // Store the input direction
        _currentInput = direction;
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement while keeping vertical velocity unchanged
        _rb.linearVelocity = new Vector2(_currentInput.x * _speed, _rb.linearVelocity.y);
    }

    private void Update()
    {
        // When Left Shift is pressed, double the movement speed (sprint)
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _speed = _baseSpeed * 2f;

        // When Left Shift is released, reset speed to normal
        if (Input.GetKeyUp(KeyCode.LeftShift))
            _speed = _baseSpeed;
    }

    // Called when jump input is triggered
    private void Jump()
    {
        // Only allow jumping if the player is grounded
        if (grounded)
        {
            // Apply upward velocity
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }

    // Detect when player touches the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    // Detect when player leaves the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = false;
    }
}