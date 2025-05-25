using UnityEngine;

public class WaveEffect : MonoBehaviour
{
    public float expandSpeed = 3f;
    public float maxRadius = 10f;
    public float fadeSpeed = 0.8f;

    private CircleCollider2D col;
    private SpriteRenderer visual;

    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        visual = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float scale = transform.localScale.x + expandSpeed * Time.deltaTime;
        transform.localScale = new Vector3(scale, scale, 1);
        col.radius = scale / 2f; // colliderµµ °°ÀÌ Ä¿Áü

        Color c = visual.color;
        c.a -= fadeSpeed * Time.deltaTime;
        visual.color = c;

        if (scale >= maxRadius || c.a <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
