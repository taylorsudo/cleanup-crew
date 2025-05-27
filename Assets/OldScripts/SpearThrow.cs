using UnityEngine;

public class SpearThrow : MonoBehaviour
{
    public GameObject spearPrefab;         // Thrown spear with Rigidbody
    public GameObject idleSpearPrefab;     // Visual-only resting spear
    public Transform throwOrigin;          // Usually Main Camera
    public Transform spearHolder;          // Empty object parented to camera

    private GameObject currentIdleSpear;
    public float throwForce = 15f;

    void Start()
    {
        if (throwOrigin == null)
        {
            throwOrigin = Camera.main?.transform;
            if (throwOrigin == null) Debug.LogError("Throw origin not assigned.");
        }

        if (spearHolder == null)
        {
            Debug.LogError("Spear holder not assigned.");
        }

        SpawnIdleSpear();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }

    void SpawnIdleSpear()
    {
        if (idleSpearPrefab != null && spearHolder != null)
        {
            currentIdleSpear = Instantiate(idleSpearPrefab, spearHolder);
            currentIdleSpear.transform.localPosition = Vector3.zero;
            currentIdleSpear.transform.localRotation = Quaternion.identity;
        }
    }

    void Throw()
    {
        // Hide the idle spear
        if (currentIdleSpear != null)
        {
            Destroy(currentIdleSpear);
        }

        // Spawn thrown spear
        Vector3 pos = throwOrigin.position + throwOrigin.forward * 0.6f - throwOrigin.up * 0.05f;
        Quaternion rot = Quaternion.LookRotation(throwOrigin.forward);
        GameObject spear = Instantiate(spearPrefab, pos, rot);

        Rigidbody rb = spear.GetComponent<Rigidbody>();
        rb.velocity = throwOrigin.forward * throwForce;
        rb.useGravity = false;

        spear.AddComponent<SpearGravity>();
        spear.AddComponent<TiltSpearOverTime>();

        Destroy(spear, 10f);

        // Respawn idle spear after delay
        Invoke(nameof(SpawnIdleSpear), 0.5f);
    }
}
