using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2f;
    public float swimRadius = 5f;
    private Vector3 target;

    void Start() => SetNewTarget();

    void Update()
    {
        // Move fish
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Rotate to face movement direction
        Vector3 direction = target - transform.position;
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Pick new target when close
        if (Vector3.Distance(transform.position, target) < 0.5f)
            SetNewTarget();
    }

    void SetNewTarget()
    {
        Vector2 random = Random.insideUnitCircle * swimRadius;
        target = transform.position + new Vector3(random.x, 0f, random.y);
    }
}
