using System.Collections;
using UnityEngine;

public class PlayerMoveNew : InputController
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpLengthInSeconds;
    
    private Transform _transform;
    private float _playerPositionY;
    
    private void Awake()
    {
        _transform = transform;
        _playerPositionY = _transform.position.y;
    }

    public override void Move(Vector3 direction)
    {
        Vector3 newPosition = _transform.position + direction * (Time.deltaTime * _speed);
        newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);
        _transform.position = newPosition;
    }

    public override void Jump()
    {
        _transform.position += new Vector3(0, _jumpForce, 0);
        StartCoroutine(PlayerFall());
    }

    private IEnumerator PlayerFall()
    {
        yield return new WaitForSecondsRealtime(_jumpLengthInSeconds);
        var position = _transform.position;
        
        position = new Vector3(position.x, _playerPositionY, position.z);
        _transform.position = position;
    }
}