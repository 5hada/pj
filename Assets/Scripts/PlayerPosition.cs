using UnityEngine;

public class PlayerPosition : MonoBehaviour
{

    Rigidbody rigid;
    Animator anim;
    SpriteRenderer sprite;
    Movement movement;

    void OnTriggerEnter(Collider other)
    {
        int currentPosition = movement.currentPositionIndex;
        if (other.name == "Select01")
        {
            currentPosition = 1;
        }
        if (other.name == "Select02")
        {
            currentPosition = 2;
        }
        if (other.name == "Select03")
        {
            currentPosition = 3;
        }
        if (other.name == "Select04")
        {
            currentPosition = 4;
        }
        if (other.name == "Select05")
        {
            currentPosition = 5;
        }
        if (other.name == "Select06")
        {
            currentPosition = 6;
        }
        if (other.name == "Select07")
        {
            currentPosition = 7;
        }
        if (other.name == "Select08")
        {
            currentPosition = 8;
        }
        if (other.name == "Select09")
        {
            currentPosition = 9;
        }

    }
}
