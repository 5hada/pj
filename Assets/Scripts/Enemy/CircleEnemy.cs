using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = 4f;
    }

    void Update()
    {
        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(Vector2 moveDir)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = moveDir.normalized * speed;
        }
    }

    bool IsVisibleFrom(Camera cam)
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        return viewportPos.x > -0.1f && viewportPos.x < 1.1f &&
               viewportPos.y > -0.1f && viewportPos.y < 1.1f;
    }
}
