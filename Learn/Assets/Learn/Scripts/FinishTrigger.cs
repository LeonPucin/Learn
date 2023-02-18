using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehaviour>();
        if (playerBehavior)
        {
            playerBehavior.TurnFinishState();
            FindObjectOfType<GameManager>().ShowFinishWindow();
        }
    }
}