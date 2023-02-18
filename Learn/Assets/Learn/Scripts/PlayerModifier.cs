using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] private float _width;
    [SerializeField] private float _height;

    [SerializeField] private Renderer _renderer;
    
    [SerializeField] private Transform _bottomSpine;
    [SerializeField] private Transform _colliderTransform;

    private static readonly int PushValue = Shader.PropertyToID("_PushValue");
    private const float WidthMultiplier = 0.0005f;
    private const float HeightMultiplier = 0.01f;
    private float _startHeight;

    private void Start()
    {
        var localScaleY = _colliderTransform.localScale.y;
        _startHeight = localScaleY;
        _height = localScaleY;
    }

    public float AddWidth(int value)
    {
        _width += value;
        _renderer.material.SetFloat(PushValue, _width * WidthMultiplier);

        return _width;
    }

    public float AddHeight(int value)
    {
        float modifierValue = value * HeightMultiplier;
        
        _height += modifierValue;
        _bottomSpine.localPosition -= new Vector3(modifierValue, 0, 0);

        _colliderTransform.localScale =
            new Vector3(1, _height, 1);

        return _height;
    }

    public void Hit(int value)
    {   
        if (_height > _startHeight)
        {
            if (AddHeight(value) < _startHeight)
                Die();
        } else if (_width > 0)
        {
            if (AddWidth(value) < 0)
                Die();
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().ShowFinishWindow();
    }
}