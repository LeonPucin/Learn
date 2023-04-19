using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CoinManager : MonoBehaviour
{
    private int _amountCoin;

    public int AmountCoin
    {
        get => _amountCoin;
        private set
        {
            _amountCoin = value;
            OnValueChanged?.Invoke(AmountCoin);
            var newValue = new IntDto(AmountCoin);
            //_onValueChangedUnity?.Invoke(newValue);
        }
    }

    public event Action<int> OnValueChanged; 
    public UnityEvent<IntDto> _onValueChangedUnity;

    private void Start()
    {
        AmountCoin = Progress.Instance._playerInfo.Coins;
    }

    public void AddCoin(int amount)
    {
        AmountCoin += amount;
    }

    public void SaveToProgress()
    {
        Progress.Instance._playerInfo.Coins = AmountCoin;
    }
}