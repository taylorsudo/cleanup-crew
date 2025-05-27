using UnityEngine;

public class FishHit : MonoBehaviour
{
    Renderer renderer;
    Color original;
    public Color hitColor = Color.red;
    public float flashTime = 0.2f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        original = renderer.material.color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spear"))
            StartCoroutine(Flash());
    }

    System.Collections.IEnumerator Flash()
    {
        renderer.material.color = hitColor;
        yield return new WaitForSeconds(flashTime);
        Destroy(gameObject);
    }
}
