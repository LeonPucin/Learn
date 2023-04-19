using System.IO;
using UnityEngine;


public class SaveLiteExample : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    [SerializeField] private string _fileName;
    [SerializeField] private string _path;
    private GameData _gameData;

    private void Awake()
    {
        _path = Path.Combine(Application.dataPath, "Saves", _fileName);
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        _gameData.position = _cube.transform.position;
        _gameData.rotation = _cube.transform.rotation;

        BinarySerializer.Serialize(_path, _gameData);
        Debug.Log("Game saved");
    }

    private void Load()
    {
        if (File.Exists(_path))
        {
            _gameData = BinarySerializer.Deserialize<GameData>(_path);
        }

        _cube.transform.position = _gameData.position;
        _cube.transform.rotation = _gameData.rotation;
        Debug.Log($"Loaded {name}'s speed: {_gameData.speed}");
    }
}