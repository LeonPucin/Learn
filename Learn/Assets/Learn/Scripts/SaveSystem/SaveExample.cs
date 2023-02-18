using UnityEngine;

public class SaveExample : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    
    private Storage _storage;
    private GameData _gameData;

    private void Awake()
    {
        _storage = new Storage();
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
        
        Debug.Log("Game saved");
        _storage.Save(_gameData);
    }

    private void Load()
    {
        _gameData = (GameData)_storage.Load(new GameData());
        
        _cube.transform.position = _gameData.position;
        _cube.transform.rotation = _gameData.rotation;
        Debug.Log($"Loaded {name}'s speed: {_gameData.speed}");
    }
}
