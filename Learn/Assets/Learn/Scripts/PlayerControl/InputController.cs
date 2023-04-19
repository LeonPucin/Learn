using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public virtual void Move(Vector3 direction)
    {
        Debug.Log($"Direction x:{direction.x}, y:{direction.y}, z: {direction.z}");
    }

    public virtual void Jump()
    {
        Debug.Log("I jump");
    }
}