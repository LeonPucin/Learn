using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();
    
    [DllImport("__Internal")]
    private static extern void GetPlayerData();

    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private RawImage _playerIcon;

    public void HelloButton()
    {
        GetPlayerData();
    }

    public void SetName(string playerName)
    {
        _playerName.text = playerName;
    }

    public void SetIcon(string path)
    {
        StartCoroutine(DownloadImage(path));
    }

    private IEnumerator DownloadImage(string path)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(path);
        yield return request.SendWebRequest();
        
        if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            _playerIcon.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}