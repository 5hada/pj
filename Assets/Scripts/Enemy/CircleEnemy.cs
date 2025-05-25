using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    public Vector2 direction = Vector2.right;  // 오른쪽으로 직선 이동
    public float speed = 2f;
    public float gridSize = 1f;

    private Vector3 nextPosition;

    void Start()
    {
        nextPosition = GetNextGridPosition();
    }

    void Update()
    {
        // 다음 격자 위치로 이동
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // 도착하면 다음 격자 위치 설정
        if (Vector3.Distance(transform.position, nextPosition) < 0.01f)
        {
            nextPosition = GetNextGridPosition();
        }

        // 카메라 밖이면 파괴
        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
    }

    Vector3 GetNextGridPosition()
    {
        return new Vector3(
            Mathf.Round(transform.position.x / gridSize + direction.x) * gridSize,
            Mathf.Round(transform.position.y / gridSize + direction.y) * gridSize,
            0f
        );
    }

    bool IsVisibleFrom(Camera cam)
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(transform.position);
        return viewportPos.x > -0.1f && viewportPos.x < 1.1f &&
               viewportPos.y > -0.1f && viewportPos.y < 1.1f;
    }
}
