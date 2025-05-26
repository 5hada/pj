using UnityEngine;
using System.Collections;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject warningPrefab;

    [SerializeField] private float warningTime = 1.0f;
    [SerializeField] private float laserTime = 0.5f;


    private float timer;

    public void LaserAttackTimer(float attackInterval)
    {
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            timer = 0f;
            Attack();
        }
    }

    void Attack()
    {
        int targetIndex = movement.currentPositionIndex;
        int xIndex = targetIndex % 4;
        int yIndex = targetIndex / 4;

        float x = xIndex;
        float y = - yIndex;

        Vector2 targetPos;
        bool horizontal = Random.Range(0, 2) == 0;

        if (horizontal)
        {
            // 수평: y 고정, x는 중앙인 0
            targetPos = new Vector2(0f, y);
            StartCoroutine(SpawnLaser(targetPos, true));
        }
        else
        {
            // 수직: x 고정, y는 중앙인 0
            targetPos = new Vector2(x, 0f);
            StartCoroutine(SpawnLaser(targetPos, false));
        }
    }


    IEnumerator SpawnLaser(Vector2 centerPos, bool isHorizontal)
    {
        GameObject warning = Instantiate(warningPrefab, centerPos, Quaternion.identity);
        if (!isHorizontal)
            warning.transform.rotation = Quaternion.Euler(0, 0, 90);

        yield return new WaitForSeconds(warningTime);
        Destroy(warning);

        GameObject laser = Instantiate(laserPrefab, centerPos, Quaternion.identity);
        if (!isHorizontal)
            laser.transform.rotation = Quaternion.Euler(0, 0, 90);

        yield return new WaitForSeconds(laserTime);
        Destroy(laser);
    }

}
