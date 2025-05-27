using UnityEngine;

public class SpearGravity : MonoBehaviour
{
    public float gravityStrength = 3f;
    Rigidbody rb;

    void Awake() => rb = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        if (rb != null && !rb.useGravity)
            rb.AddForce(Vector3.down * gravityStrength, ForceMode.Acceleration);
    }
}
