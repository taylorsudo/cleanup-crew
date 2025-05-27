using UnityEngine;

public class InfoImageTarget : MonoBehaviour
{
    private bool isFading = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isFading) return;

        if (collision.gameObject.CompareTag("Spear"))
        {
            isFading = true;
            Debug.Log("InfoImage hit. Starting fade out.");
            StartCoroutine(FadeOut(6f));
        }
    }

    private System.Collections.IEnumerator FadeOut(float duration)
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogWarning("No renderer found on InfoImageTarget");
            yield break;
        }

        Color originalColor = rend.material.color;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            rend.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rend.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        gameObject.SetActive(false);
    }
}
