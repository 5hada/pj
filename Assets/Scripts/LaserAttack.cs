using UnityEngine;
using System.Collections;

public class LaserAttack : MonoBehaviour
{
    [SerializeField] private GameObject warningPrefab;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float warningTime = 1.0f;
    [SerializeField] private float laserTime = 0.5f;
    [SerializeField] private float gridSize = 1.0f;

    public void AttackLine(Vector2 playerPos, bool horizontal)
    {
        StartCoroutine(AttackRoutine(playerPos, horizontal));
    }

    private IEnumerator AttackRoutine(Vector2 playerPos, bool horizontal)
    {
        // 격자 정렬
        float x = Mathf.Round(playerPos.x / gridSize) * gridSize;
        float y = Mathf.Round(playerPos.y / gridSize) * gridSize;

        Vector2 spawnPos = horizontal ? new Vector2(0, y) : new Vector2(x, 0);
        Vector2 scale = horizontal ? new Vector2(30f, 0.2f) : new Vector2(0.2f, 30f);

        // 1. 경고 선 생성
        GameObject warning = Instantiate(warningPrefab, spawnPos, Quaternion.identity);
        warning.transform.localScale = scale;

        yield return new WaitForSeconds(warningTime);
        Destroy(warning);

        // 2. 레이저 선 생성
        GameObject laser = Instantiate(laserPrefab, spawnPos, Quaternion.identity);
        laser.transform.localScale = scale;

        yield return new WaitForSeconds(laserTime);
        Destroy(laser);
    }
}
