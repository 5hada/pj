using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerItem : MonoBehaviour
{
    ItemType currentItem;
    [SerializeField] private GameObject itemInven;
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private Sprite healIcon;
    [SerializeField] private Sprite waveIcon;
    [SerializeField] private GameObject wavePrefab;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentItem = ItemType.None;
        spriteRenderer = itemInven.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;
    }

    private void Update()
    {
        if (InputManager.Instance.IsSpacePressed())
        {
            switch (currentItem)
            {
                case (ItemType.Heal):
                    playerHP.Heal();
                    currentItem = ItemType.None;
                    spriteRenderer.sprite = null;
                    break;
                case (ItemType.Wave):
                    Wave();
                    currentItem = ItemType.None;
                    spriteRenderer.sprite = null;
                    break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!Movement.isMoving && other.CompareTag("Item"))
        {
            if (other.name == "HealItem(Clone)")
            {
                currentItem = ItemType.Heal;
                spriteRenderer.sprite = healIcon;
                Destroy(other.gameObject);
            }
            else if (other.name == "WaveItem(Clone)")
            {
                currentItem = ItemType.Wave;
                spriteRenderer.sprite = waveIcon;
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }


    private void Wave()
    {
        Instantiate(wavePrefab, transform.position, Quaternion.identity);
        currentItem = ItemType.None;
    }

}
enum ItemType
{
    None,
    Heal,
    Wave
}