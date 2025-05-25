using UnityEngine;

public class GroupMover : MonoBehaviour
{
    [Header("씬에서 직접 배치한 오브젝트들")]
    public GameObject[] objectsToMove;

    public float stepSize = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveGroup(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveGroup(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveGroup(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveGroup(Vector2.down);
        }
    }

    public void MoveGroup(Vector2 direction)
    {
        Vector3 offset = new Vector3(direction.x, direction.y, 0f) * stepSize;

        foreach (GameObject obj in objectsToMove)
        {
            obj.transform.position += offset;
        }
    }
}
