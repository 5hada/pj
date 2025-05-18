using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetHorizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public float GetVertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
    public bool IsShiftPressed()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }
    public bool IsSpacePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public bool IsEnterPressed()
    {
        return Input.GetKeyDown(KeyCode.Return);
    }
    public bool IsExitPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }
}