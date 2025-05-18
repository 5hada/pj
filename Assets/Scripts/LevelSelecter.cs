using UnityEngine;
using UnityEngine.Rendering;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Object Player;
    [SerializeField]
    private Object Select01;
    [SerializeField]
    private Object Select02;
    [SerializeField]
    private Object Select03;
    [SerializeField]
    private Object Select04;
    [SerializeField]
    private Object Select05;
    [SerializeField]
    private Object Select06;
    [SerializeField]
    private Object Select07;
    [SerializeField]
    private Object Select08;
    [SerializeField]
    private Object Select09;

    private void Awake()
    {
        
    }

    void select_check()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

    }


}
