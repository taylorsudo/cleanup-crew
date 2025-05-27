using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicsBasedVRMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public InputActionProperty moveInput;
    public InputActionProperty jumpInput;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        // Convert movement to local space
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0f; // Prevent vertical drifting

        rb.AddForce(move * moveSpeed, ForceMode.Acceleration);
    }

    void Update()
    {
        if (jumpInput.action.WasPressedThisFrame())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
