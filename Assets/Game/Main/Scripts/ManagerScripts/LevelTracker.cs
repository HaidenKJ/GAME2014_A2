using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTracker : MonoBehaviour
{
    public const string LastLevelKey = "LastLevelIndex";

    [SerializeField] private int gameOverIndex = 5;

    // Hook to a temporary "Finish Level" button (later: call it when the player wins or dies)
    public void EndLevel()
    {
        PlayerPrefs.SetInt(LastLevelKey, SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(gameOverIndex);
    }
}