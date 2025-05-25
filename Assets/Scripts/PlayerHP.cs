using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    int maxHP = 3;
    [SerializeField]
    int currentHP;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        HpColor();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHP -= 1;
        }
    }


    void HpColor()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    void Failed()
    {
        if (currentHP <= 0)
        {
            SceneController.Instance.LoadScene("GameOver");
        }
    }
}
