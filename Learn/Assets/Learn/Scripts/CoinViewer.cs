using TMPro;
using UnityEngine;

public class CoinViewer : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpdateText(_coinManager.AmountCoin);
    }

    private void OnEnable()
    {
        _coinManager.OnValueChanged += UpdateText;
    }

    private void OnDisable()
    {
        _coinManager.OnValueChanged -= UpdateText;
    }

    private void UpdateText(int newValue)
    {
        _text.text = newValue.ToString();
    }
}
