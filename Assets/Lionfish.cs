using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lionfish : MonoBehaviour
{
    private Renderer[] renderers;
    private List<Color> originalColors = new List<Color>();

    void Start()
    {
        // Get all renderers in children
        renderers = GetComponentsInChildren<Renderer>();

        // Store original colors
        foreach (Renderer rend in renderers)
        {
            originalColors.Add(rend.material.color);
        }
    }

    public void OnHit()
    {
        Debug.Log("Lionfish hit!");
        StartCoroutine(FlashAndDisappear());
    }

    private IEnumerator FlashAndDisappear()
    {
        // Flash red
        foreach (Renderer rend in renderers)
        {
            rend.material.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f);

        // Restore original color
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = originalColors[i];
        }

        yield return new WaitForSeconds(0.1f);

        // Disable fish
        gameObject.SetActive(false);

        // Register kill with GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterKill();
        }
    }
}
