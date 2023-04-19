using UnityEngine;

public class BoxMove : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(0, 0.1f, 0);
    }
}