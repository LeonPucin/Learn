using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private int _widthPrice;
    [SerializeField] private int _heightPrice;

    [SerializeField] private CoinManager _coinManager;

    public void BuyWidth()
    {
        if (_coinManager.AmountCoin > _widthPrice)
        {
            _coinManager.AddCoin(-_widthPrice); // Ну и говно
        }
    }

    public void BuyHeight()
    {
    }
}