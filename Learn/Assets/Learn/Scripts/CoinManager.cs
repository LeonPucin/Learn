using System;
using UnityEngine;

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
        }
    }

    public event Action<int> OnValueChanged;

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