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
        if (Input.GetKeyDown(KeyCode.D)) return 1f;
        else if (Input.GetKeyDown(KeyCode.A)) return -1f;
        return 0f;
    }
    public float GetVertical()
    {
        if (Input.GetKeyDown(KeyCode.W)) return 1f;
        else if (Input.GetKeyDown(KeyCode.S)) return -1f;
        return 0f;
    }
    public bool IsShiftPressed()
    {
        return Input.GetKey(KeyCode.LeftShift);
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