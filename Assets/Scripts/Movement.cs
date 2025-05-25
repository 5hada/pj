using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public int gridSize = 3; 
    public float moveSpeed = 20.0f;
    public static bool isMoving = false;
    public (int x, int y) currentPosition = (0, 0);
    private string currentScene;
    public int currentPositionIndex;

    private Animator animator;



    private void Awake()
    {
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = new Vector2(0, 0);
        currentPosition = (0, 0);
        currentPositionIndex = 0;
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        isMoving = false;
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
        int prevIndex = currentPositionIndex;
        int moveAmount = shift ? 2 : 1;
        int maxIndex = gridSize * gridSize - 1;

        int prevRow = currentPositionIndex / gridSize;
        int prevCol = currentPositionIndex % gridSize;

        int row = prevRow;
        int col = prevCol;

        if (horizontal > 0)
            if (col == gridSize - 1)
                col = 0;
            else if (col == gridSize - 2)
                col = gridSize - 1;
            else col = col + moveAmount;
        else if (horizontal < 0)
            if (col == 0)
                col = gridSize - 1;
            else if (col == 1)
                col = 0;
            else col = col - moveAmount;

        if (vertical > 0)
            if (row == 0)
                row = gridSize - 1;
            else if (row == 1)
                row = 0;
            else row = row - moveAmount;
        else if (vertical < 0)
            if (row == gridSize - 1)
                row = 0;
            else if (row == gridSize - 2)
                row = gridSize - 1;
            else row = row + moveAmount;

        currentPositionIndex = row * gridSize + col;

        if (input != Vector3.zero)
        {
            Vector3 targetPos = IndexToPosition(currentPositionIndex, gridSize);

            MoveType moveType;

            int dist = Mathf.Abs(currentPositionIndex - prevIndex);

            if (dist == 1 || dist == gridSize)
            {
                moveType = MoveType.Normal1;
            }
            else if (dist == 2 || dist == gridSize * 2)
            {
                moveType = MoveType.Double;
            }
            else
            {
                moveType = MoveType.Wrapped;
            }

            PlayMoveAnimation(moveType);

            StartCoroutine(MoveToPosition(targetPos));
        }
    }


    public Vector3 IndexToPosition(int index, int gridSize)
    {
        float stepSize;
        if (gridSize == 3) stepSize = 1.5f;
        else stepSize = 1f;

        int x = index % gridSize;       // 열 (왼쪽 0 → 오른쪽 2)
        int y = index / gridSize;       // 행 (아래 0 → 위 2)
        float worldX = x * stepSize;
        float worldY = -y * stepSize;  // 아래로 내려갈수록 y 감소

        return new Vector3(worldX, worldY, 0f);
    }
    void PlayMoveAnimation(MoveType type)
    {
        switch (type)
        {
            case MoveType.Normal1:
                animator.SetTrigger("Move1");
                break;
            case MoveType.Double:
                animator.SetTrigger("Move2");
                break;
            case MoveType.Wrapped:
                animator.SetTrigger("Warp");
                break;
        }
    }

}

enum MoveType
{
    Normal1,     // 일반 이동 (1칸)
    Double,      // 두 칸 이동 (Shift)
    Wrapped      // 벽을 넘어 반대편으로 이동
}
