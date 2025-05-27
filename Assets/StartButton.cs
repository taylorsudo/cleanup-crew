using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject title;
    public GameObject infoImage;

    private bool wasHit = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (wasHit) return;

        if (collision.gameObject.CompareTag("Spear"))
        {
            wasHit = true;

            // Hide the title
            if (title != null)
                title.SetActive(false);

            // Hide the start button visuals and collider
            Renderer rend = GetComponent<Renderer>();
            Collider col = GetComponent<Collider>();

            if (rend != null)
                rend.enabled = false;
            if (col != null)
                col.enabled = false;

            // Show the info image (do not fade it here)
            if (infoImage != null)
                infoImage.SetActive(true);
        }
    }
}
