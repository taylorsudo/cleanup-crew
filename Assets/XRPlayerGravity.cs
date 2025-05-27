using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(CharacterController))]
public class XRPlayerGravity : MonoBehaviour
{
    public float gravity = -9.81f;
    public float fallSpeed = 0f;
    public float groundedOffset = 0.1f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
    }

    void ApplyGravity()
    {
        bool isGrounded = CheckIfGrounded();

        if (!isGrounded)
        {
            fallSpeed += gravity * Time.deltaTime;
        }
        else if (fallSpeed < 0)
        {
            fallSpeed = 0f;
        }

        Vector3 gravityMove = new Vector3(0, fallSpeed, 0);
        characterController.Move(gravityMove * Time.deltaTime);
    }

    bool CheckIfGrounded()
    {
        // A simple raycast downwards
        return Physics.Raycast(transform.position, Vector3.down, groundedOffset + 0.1f);
    }
}
