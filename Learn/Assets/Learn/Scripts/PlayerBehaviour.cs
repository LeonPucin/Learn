using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PreFinishBehavior _preFinishBehavior;
    [SerializeField] private Animator _animator;
    
    private static readonly int TurnOnDance = Animator.StringToHash("turnOnDance");

    private void Awake()
    {
        _playerMove.enabled = false;
        _preFinishBehavior.enabled = false;
    }

    public void Play()
    {
        _playerMove.enabled = true;
    }

    public void TurnPreFinishState()
    {
        _playerMove.enabled = false;
        _preFinishBehavior.enabled = true;
    }

    public void TurnFinishState()
    {
        _preFinishBehavior.enabled = false;
        _animator.SetTrigger(TurnOnDance);
    }
}
