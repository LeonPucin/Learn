using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _sensitivityInput;
    
    [SerializeField] private float _speed;
    [SerializeField] private Animator _playerAnimator;

    private Transform _transform;
    private float _oldMousePositionX;
    private float _euleY;
    private readonly int _isRun = Animator.StringToHash("isRun");

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _playerAnimator.SetBool(_isRun, true);
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = _transform.position + _transform.forward * (Time.deltaTime * _speed);
            newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);
            transform.position = newPosition;
            
            float deltaX = (Input.mousePosition.x - _oldMousePositionX) * _sensitivityInput;
            _oldMousePositionX = Input.mousePosition.x;

            _euleY += deltaX;
            _euleY = Mathf.Clamp(_euleY, -70, 70);
            transform.eulerAngles = new Vector3(0, _euleY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _playerAnimator.SetBool(_isRun, false);
        }
    }
}