using UnityEngine;

[CreateAssetMenu(fileName = "ChestInfo", menuName = "Learn/ChestInfo")]
public class ChestInfo : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _spriteIcon;

    public string ID => _id;
    public GameObject Prefab => _prefab;
    public Sprite SpriteIcon => _spriteIcon;
}
