using UnityEngine;

public class InfoIcon : MonoBehaviour
{
    public GameObject infoImage; // Assigned in inspector

    private bool wasHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (wasHit) return;

        if (collision.gameObject.CompareTag("Spear"))
        {
            wasHit = true;
            if (infoImage != null)
            {
                infoImage.SetActive(true);
                StartCoroutine(FadeOut(infoImage));
            }
        }
    }

    private System.Collections.IEnumerator FadeOut(GameObject target)
    {
        // Assume it's a material or image with transparency
        Renderer rend = target.GetComponent<Renderer>();
        if (rend == null) yield break;

        Color color = rend.material.color;
        float duration = 10f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            rend.material.color = new Color(color.r, color.g, color.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rend.material.color = new Color(color.r, color.g, color.b, 0f);
        target.SetActive(false); // fully fade out and hide
    }
}
