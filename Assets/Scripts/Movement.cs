using UnityEngine;

public class Movement : MonoBehaviour
{
    public float stepSize = 10.0f;


    private void Awake()
    {
        transform.position = new Vector2(0, 0);
    }



    void Update()
    {
        float Horizontal = InputManager.Instance.GetHorizontal();
        float Vertical = InputManager.Instance.GetVertical();
        bool Shift = InputManager.Instance.IsShiftPressed();

        Vector2 ToMove = new Vector2(Horizontal, Vertical).normalized;

        if (ToMove != Vector2.zero)
        {
            if (Shift)
            {
                transform.position += (Vector3)ToMove * stepSize * 2.0f * Time.deltaTime;
            }
            else
            {
                transform.position += (Vector3)ToMove * stepSize * Time.deltaTime;
            }
        }
    }
}
