using UnityEngine;

public class TiltSpearOverTime : MonoBehaviour
{
    private Rigidbody rb;
    public float tiltSpeed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude > 0.01f)
        {
            Quaternion look = Quaternion.LookRotation(rb.velocity.normalized);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, look, Time.fixedDeltaTime * tiltSpeed));
        }
    }
}
