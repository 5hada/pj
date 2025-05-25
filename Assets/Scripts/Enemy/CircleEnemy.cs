using UnityEngine;

public class CircleEnemy : MonoBehaviour
{
    public Vector2 direction = Vector2.right;  // ���������� ���� �̵�
    public float speed = 2f;
    public float gridSize = 1f;

    private Vector3 nextPosition;

    void Start()
    {
        nextPosition = GetNextGridPosition();
    }

    void Update()
    {
        // ���� ���� ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // �����ϸ� ���� ���� ��ġ ����
        if (Vector3.Distance(transform.position, nextPosition) < 0.01f)
        {
            nextPosition = GetNextGridPosition();
        }

        // ī�޶� ���̸� �ı�
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
