using UnityEngine;

public class PreFinishBehavior : MonoBehaviour
{
    private void Update()
    {
        var playerTransform = transform;
        float x = Mathf.MoveTowards(playerTransform.position.x, 0, Time.deltaTime * 2f);
        float z = playerTransform.position.z + 6f * Time.deltaTime;
        playerTransform.position = new Vector3(x, 0, z);

        float rotationY = 
            Mathf.MoveTowardsAngle(playerTransform.eulerAngles.y, 0, Time.deltaTime * 100f);
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
    }
}