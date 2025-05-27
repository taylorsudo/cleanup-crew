using UnityEngine;

public class Spear : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lionfish"))
        {
            Lionfish lf = collision.gameObject.GetComponent<Lionfish>();
            if (lf != null)
            {
                lf.OnHit();
            }

            Destroy(gameObject); // Destroy spear on hit
        }
    }
}
