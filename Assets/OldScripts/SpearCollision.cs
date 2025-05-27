using UnityEngine;

public class SpearCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Fish hit!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
