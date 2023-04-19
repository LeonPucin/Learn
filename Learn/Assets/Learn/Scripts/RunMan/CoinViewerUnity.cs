using TMPro;
using UnityEngine;

public class CoinViewerUnity : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(IntDto newValue)
    {
        _text.text = newValue.Value.ToString();
    }
}