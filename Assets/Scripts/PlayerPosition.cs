using UnityEngine;

public class PlayerPosition : MonoBehaviour
{

    Rigidbody rigid;
    Animator anim;
    SpriteRenderer sprite;
    public int currentPosition = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Select01")
        {
            currentPosition = 1;
        }
        
    }
}
