using UnityEngine;

public class UnderwaterFog : MonoBehaviour
{
    [Header("Underwater Fog Settings")]
    public Color fogColor = new Color(0f, 0.4f, 0.7f, 1f);
    [Range(0f, 0.1f)]
    public float fogDensity = 0.04f;

    [Header("Tag Settings")]
    public string playerTag = "Player";

    private Color originalFogColor;
    private float originalFogDensity;
    private bool originalFogEnabled;

    private void Start()
    {
        originalFogColor = RenderSettings.fogColor;
        originalFogDensity = RenderSettings.fogDensity;
        originalFogEnabled = RenderSettings.fog;

        Debug.Log("UnderwaterFog script active on: " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag(playerTag))
        {
            Debug.Log("Entered underwater zone. Applying fog.");
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;
            RenderSettings.fog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.name);

        if (other.CompareTag(playerTag))
        {
            Debug.Log("Exited underwater zone. Restoring fog.");
            RenderSettings.fogColor = originalFogColor;
            RenderSettings.fogDensity = originalFogDensity;
            RenderSettings.fog = originalFogEnabled;
        }
    }
}
