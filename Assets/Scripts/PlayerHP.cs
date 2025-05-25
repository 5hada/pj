using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    int maxHP = 3;
    int currentHP;
    public float invincibleTime = 1.5f; // 무적 지속 시간 (초)
    bool isInvincible = false; // 플레이어가 무적 상태인지 여부
    public float blinkInterval = 0.1f;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameOverManager gameOverManager;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HpColor();
        if (currentHP <= 0)
        {
            gameOverManager.ShowGameOver();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isInvincible && !Movement.isMoving)
            {
                TakeDamage();
            }
        }
    }

    void TakeDamage()
    {
        currentHP -= 1;
        StartCoroutine(InvincibleCoroutine());
    }

    IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        float elapsed = 0f;

        while (elapsed < invincibleTime)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval * 2;
        }

        isInvincible = false;
        spriteRenderer.enabled = true;
    }

    void HpColor()
    {
        if (currentHP == 3)
        {
            spriteRenderer.color = new Color32(224,141,45,255);
        }
        else if (currentHP == 2)
        {
            spriteRenderer.color = new Color32(107, 98, 164, 255);
        }
        else if (currentHP == 1)
        {
            spriteRenderer.color = new Color32(243, 70, 70, 255);
        }
    }    

}
