using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private CoinManager _coinManager;

    private void Awake()
    {
        _levelText.text = SceneManager.GetActiveScene().name;

        _finishWindow.SetActive(false);
    }

    public void Play()
    {
        Progress.Instance.Save();

        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int nextLevelID = SceneManager.GetActiveScene().buildIndex + 1;
        _coinManager.SaveToProgress();
        Progress.Instance._playerInfo.LevelID = nextLevelID;

        Progress.Instance.Save();

        if (nextLevelID < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelID);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}