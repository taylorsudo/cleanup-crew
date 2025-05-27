using UnityEngine;
using UnityEngine.InputSystem;

public class SpearThrower : MonoBehaviour
{
    public GameObject spearPrefab;
    public Transform spearSpawnPoint;
    public float throwForce = 15f;

    public InputActionReference activateAction; // <-- Drag from XR Controller

    private void OnEnable()
    {
        if (activateAction != null)
            activateAction.action.Enable();
    }

    private void OnDisable()
    {
        if (activateAction != null)
            activateAction.action.Disable();
    }

    private void Update()
    {
        if (activateAction != null && activateAction.action.WasPressedThisFrame())
        {
            ThrowSpear();
        }
    }

    void ThrowSpear()
    {
        GameObject spear = Instantiate(spearPrefab, spearSpawnPoint.position, spearSpawnPoint.rotation);
        Rigidbody rb = spear.GetComponent<Rigidbody>();
        rb.velocity = spearSpawnPoint.forward * throwForce;
    }
}
