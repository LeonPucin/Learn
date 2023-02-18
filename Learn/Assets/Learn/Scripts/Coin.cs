using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue;
    [SerializeField] private float _rotationSpeed;

    private CoinManager _coinManager;

    private void Awake()
    {
        _coinManager = FindObjectOfType<CoinManager>();
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        _coinManager.AddCoin(_coinValue);
        Destroy(gameObject);
    }
}
