using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("Build Settings indexes")]
    [SerializeField] private int mainMenuIndex = 0;
    [SerializeField] private int firstLevelIndex = 2; // Level 1
    [SerializeField] private int lastLevelIndex = 4; // Level 3
    public void OnPlayAgainPressed()
    {
        int level = PlayerPrefs.GetInt(LevelTracker.LastLevelKey, firstLevelIndex);
        LoadByIndex(level);
    }
    public void OnNextLevelPressed()
    {
        int level = PlayerPrefs.GetInt(LevelTracker.LastLevelKey, firstLevelIndex);

        if (level < lastLevelIndex)
        {
            LoadByIndex(level + 1);
        }
        else
        {
            LoadByIndex(mainMenuIndex); // finished the last level
        }
    }

    public void OnMainMenuPressed()
    {
        LoadByIndex(mainMenuIndex);
    }

    public void OnQuitPressed()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

    private void LoadByIndex(int index)
    {
        if (index < 0 || index >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Build index " + index + " is not in Build Settings. Scene count: " + SceneManager.sceneCountInBuildSettings);
            return;
        }
        SceneManager.LoadScene(index);
    }
}