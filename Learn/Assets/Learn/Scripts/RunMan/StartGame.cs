using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);
        
        int nextLevelID = Progress.Instance._playerInfo.LevelID;
        
        if (nextLevelID < SceneManager.sceneCountInBuildSettings && nextLevelID != 0)
        {
            SceneManager.LoadScene(nextLevelID);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
