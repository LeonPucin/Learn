using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private DeformationType _deformationType;

    [SerializeField] private GateAppearance _gateAppearance;

    private void OnValidate()
    {
        _gateAppearance.UpdateVisual(_value, _deformationType);
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier != null)
        {
            if (_deformationType == DeformationType.Width)
                playerModifier.AddWidth(_value);
            else if (_deformationType == DeformationType.Height)
                playerModifier.AddHeight(_value);
            
            Destroy(gameObject);
        }
    }
}