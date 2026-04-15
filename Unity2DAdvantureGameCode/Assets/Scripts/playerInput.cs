using UnityEngine;
using UnityEngine.Events;

// This script handles player input and sends it through events
public class PlayerInput : MonoBehaviour
{
    [Space]

    // Event that sends movement input (Vector2) to other scripts
    public UnityEvent<Vector2> OnInputReceived = new UnityEvent<Vector2>();

    // Event that triggers when jump input is pressed
    public UnityEvent OnJumpReceived = new UnityEvent();

    // Stores the last movement input to avoid unnecessary event calls
    private Vector2 _lastInput;

    void Update()
    {
        // Get horizontal input (-1 for left, 1 for right, 0 for none)
        float horizontal = Input.GetAxisRaw("Horizontal");

        // Create a movement vector (only horizontal movement here)
        Vector2 movement = new Vector2(horizontal, 0f);

        // Only send input event if the input has changed
        if (movement != _lastInput)
        {
            OnInputReceived.Invoke(movement);
            _lastInput = movement;
        }

        // Check if the space key is pressed (jump input)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger the jump event
            OnJumpReceived.Invoke();
        }
    }
}