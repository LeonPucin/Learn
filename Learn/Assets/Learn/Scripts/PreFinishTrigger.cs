using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehaviour>();
        if (playerBehavior)
        {
            playerBehavior.TurnPreFinishState();
        }
    }
}
