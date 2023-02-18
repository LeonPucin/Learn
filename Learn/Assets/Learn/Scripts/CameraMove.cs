using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private Transform _targetTransform;

    private void Awake()
    {
        _targetTransform = _target.transform;
        transform.parent = null;
    }

    private void LateUpdate()
    {
        if (_target)
            transform.position = _targetTransform.position;
    }
}