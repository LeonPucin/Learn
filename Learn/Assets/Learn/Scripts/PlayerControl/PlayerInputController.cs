using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private InputController _controllable;

    private void Awake()
    {
        _controllable = GetComponent<InputController>();

        if (_controllable == null)
            throw new NullReferenceException($"Missing {nameof(InputController)} component on the {name}");
    }

    private void Update()
    {
        ReadMove();
        ReadJump();
    }

    private void ReadMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        vertical = Mathf.Clamp(vertical, 0, 1);
        
        var direction = new Vector3(horizontal, 0, vertical);
        
        _controllable.Move(direction);
    }

    private void ReadJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controllable.Jump();
        }
    }
}