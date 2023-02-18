using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateAppearance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _panel;
    [SerializeField] private Image _topPanel;

    [SerializeField] private Color _positive;
    [SerializeField] private Color _negative;

    [SerializeField] private GameObject _expandLabel;
    [SerializeField] private GameObject _shrinkLabel;
    [SerializeField] private GameObject _upLabel;
    [SerializeField] private GameObject _downLabel;

    public void UpdateVisual(int value, DeformationType deformationType)
    {
        string prefix = "";

        if (value > 0)
        {
            prefix = "+";
            SetGateColor(_positive);
        }
        else if (value < 0)
        {
            SetGateColor(_negative);
        }
        else
        {
            SetGateColor(Color.gray);
        }

        _text.text = prefix + value;

        TurnLabel(deformationType, value);
    }

    private void SetGateColor(Color color)
    {
        _panel.color = BuildColor(color, _panel.color.a);
        _topPanel.color = BuildColor(color, _topPanel.color.a);
    }

    private Color BuildColor(Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }

    private void TurnLabel(DeformationType typeLabel, int value)
    {
        SetActiveLabels(false);

        if (value >= 0)
        {
            if (typeLabel == DeformationType.Width)
                _expandLabel.SetActive(true);
            else if (typeLabel == DeformationType.Height)
                _upLabel.SetActive(true);
        }
        else
        {
            if (typeLabel == DeformationType.Width)
                _shrinkLabel.SetActive(true);
            else if (typeLabel == DeformationType.Height)
                _downLabel.SetActive(true);
        }
    }

    private void SetActiveLabels(bool isActive)
    {
        _expandLabel.SetActive(isActive);
        _shrinkLabel.SetActive(isActive);
        _upLabel.SetActive(isActive);
        _downLabel.SetActive(isActive);
    }
}