using UnityEngine;
using UnityEngine.Rendering;

public class Bricks : MonoBehaviour
{
    [SerializeField] private GameObject _bricksEffect;
    [SerializeField] private int _value;

    [SerializeField] private Volume _volume;

    private void OnTriggerEnter(Collider other)
    {
        var playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier)
        {
            playerModifier.Hit(_value);
            Destroy(gameObject);
            Instantiate(_bricksEffect, transform.position, transform.rotation);
        }
    }
}