using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private StageTimer stageTimer;
    private float timer;
    
    public List<GameObject> itemPrefabs; // 아이템 종류 리스트

    public float spawnInterval = 15f;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SummonItem();
            timer = 0f;
        }
    }

    void SummonItem()
    {
        int itemIndex = Random.Range(0, itemPrefabs.Count);
        int PositionIndex = Random.Range(0, 16);

        Instantiate(itemPrefabs[itemIndex], GetSpawnPosition(PositionIndex), Quaternion.identity);
    }

    Vector2 GetSpawnPosition(int positionIndex)
    {
        float x = positionIndex % 4;
        float y = positionIndex / 4;
        return new Vector2(x,-y);
    }
}
