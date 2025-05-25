using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    public int gridSize = 4;
    public float cellSize = 1f;
    public Sprite gridCellSprite;

    void Start()
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                GameObject cell = new GameObject($"Cell_{x}_{y}");
                cell.transform.parent = transform;
                cell.transform.position = new Vector3(x * cellSize, y * -cellSize, 0);

                SpriteRenderer sr = cell.AddComponent<SpriteRenderer>();
                sr.sprite = gridCellSprite;
                sr.sortingOrder = 1;
            }
        }
    }
}