using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // 적 종류 리스트
    public float spawnInterval = 2f;

    [SerializeField]
    private StageTimer stageTimer;

    private Camera cam;
    private float timer;

    void Start()
    {
        cam = Camera.main;
        spawnInterval = 2f;
    }

    void Update()
    {
        float remainTime = stageTimer.GetTimeRemaining();
        if (remainTime > 80f)
        {
            EnemySpawnTimer(2f);
        }
        else if (remainTime > 60f)
        {
            EnemySpawnTimer(1.5f);
        }
        else if (remainTime > 30f)
        {
            EnemySpawnTimer(1f);
        }
        else if (remainTime <= 15f)
        {
            EnemySpawnTimer(1.5f);
        }
    }

    void EnemySpawnTimer(float spawnInterval)
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }
    void SpawnEnemy()
    {
        GameObject prefab = enemyPrefabs[0];

        Vector2 spawnPos = Vector2.zero;
        Vector2 moveDir = Vector2.zero;

        float camHeight = cam.orthographicSize * 2f;
        float camWidth = camHeight * cam.aspect;
        float left = cam.transform.position.x - camWidth / 2;
        float right = cam.transform.position.x + camWidth / 2;
        float top = cam.transform.position.y + camHeight / 2;
        float bottom = cam.transform.position.y - camHeight / 2;

        int side = Random.Range(0, 4); // 0: 왼쪽, 1: 오른쪽, 2: 위, 3: 아래
        int pos = Random.Range(0, 4); // 시계방향

        switch (side)
        {
            case 0: spawnPos = new Vector2(left, -pos); moveDir = Vector2.right; break;
            case 1: spawnPos = new Vector2(right, -pos); moveDir = Vector2.left; break;
            case 2: spawnPos = new Vector2(pos, top); moveDir = Vector2.down; break;
            case 3: spawnPos = new Vector2(pos, bottom); moveDir = Vector2.up; break;
        }

        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);
        enemy.GetComponent<CircleEnemy>().Initialize(moveDir);
    }

}
