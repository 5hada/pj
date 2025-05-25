using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public int gridSize = 3; 
    public float moveSpeed = 20.0f;
    private bool isMoving = false;
    public (int x, int y) currentPosition = (0, 0);
    private string currentScene;
    public int currentPositionIndex;



    private void Awake()
    {
        transform.position = new Vector2(0, 0);
        currentPosition = (0, 0);
        currentPositionIndex = 0;
    }

    private void Start()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        float Horizontal = InputManager.Instance.GetHorizontal();
        float Vertical = InputManager.Instance.GetVertical();
        bool Shift = InputManager.Instance.IsShiftPressed();

        Vector3 input = new Vector3(Horizontal, Vertical).normalized;

        if (!isMoving)
        {
            switch (currentScene)
            {
                case "LevelSelect":
                    gridSize = 3;
                    GridMove(input, Horizontal, Vertical, gridSize, Shift);
                    break;
                default:
                    gridSize = 4;
                    GridMove(input, Horizontal, Vertical, gridSize, Shift);
                    break;
            }
        }
    }

    IEnumerator MoveToPosition(Vector3 target)
    {
        isMoving = true;

        Vector3 start = transform.position;
        float elapsed = 0f;

        while (elapsed < 0.1f)
        {
            transform.position = Vector3.Lerp(start, target, elapsed / 0.1f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
        isMoving = false;
    }

    void GridMove(Vector3 input, float horizontal, float vertical, int gridSize, bool shift)
    {
        int index = currentPositionIndex;
        int totalCells = gridSize * gridSize;

        int row = index / gridSize;
        int col = index % gridSize;

        int moveAmount = shift ? 2 : 1;

        // ���� �̵�
        if (horizontal > 0)
            col = (col + moveAmount) % gridSize;
        else if (horizontal < 0)
            col = (col - moveAmount + gridSize) % gridSize;

        // ���� �̵�
        if (vertical > 0)
            row = (row - moveAmount + gridSize) % gridSize; // ���� �̵� �� row ����
        else if (vertical < 0)
            row = (row + moveAmount) % gridSize; // �Ʒ��� �̵� �� row ����

        currentPositionIndex = row * gridSize + col;


        if (input != Vector3.zero)
        {
            Vector3 targetPosition = IndexToPosition(currentPositionIndex, gridSize);
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    public Vector3 IndexToPosition(int index, int gridSize)
    {
        float stepSize;
        if (gridSize == 3) stepSize = 1.5f;
        else stepSize = 1f;

        int x = index % gridSize;       // �� (���� 0 �� ������ 2)
        int y = index / gridSize;       // �� (�Ʒ� 0 �� �� 2)
        float worldX = x * stepSize;
        float worldY = -y * stepSize;  // �Ʒ��� ���������� y ����

        return new Vector3(worldX, worldY, 0f);
    }

}
