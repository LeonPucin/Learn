using UnityEngine;

public class ScriptableExample : MonoBehaviour
{
    private void Start()
    {
        var allChestInfo = Resources.LoadAll<ChestInfo>("");
        foreach (var chestInfo in allChestInfo)
        {
            Debug.Log(chestInfo.ID);
        }
    }
}
