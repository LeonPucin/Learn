using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public int Coins;
    public float Width;
    public float Height;
    public int LevelID;

    public override string ToString()
    {
        return $"{nameof(Coins)}: {Coins}\n" +
               $"{nameof(Width)}: {Width}\n" +
               $"{nameof(Height)}: {Height}\n" +
               $"{nameof(LevelID)}: {LevelID}\n";
    }
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();


    [SerializeField] private TextMeshProUGUI _playerInfoText;

    public PlayerInfo _playerInfo;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Load()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        LoadExtern();
#endif
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(_playerInfo);
#if !UNITY_EDITOR && UNITY_WEBGL
        SaveExtern(json);
#endif
    }

    public void SetPlayerInfo(string date)
    {
        _playerInfo = JsonUtility.FromJson<PlayerInfo>(date);
        if (_playerInfoText)
            _playerInfoText.text = _playerInfo.ToString();
    }
}