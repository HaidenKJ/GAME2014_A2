using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionManager : MonoBehaviour
{
    [Header("Build Settings indexes")]
    [SerializeField] private int continueSceneIndex = 2;
    [SerializeField] private int backSceneIndex = 0;

    public void OnContinuePressed()
    {
        LoadByIndex(continueSceneIndex);
    }

    public void OnBackPressed()
    {
        LoadByIndex(backSceneIndex);
    }

    private void LoadByIndex(int index)
    {
        if (index < 0 || index >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Build index " + index + " is not in Build Settings. Scene count: " + SceneManager.sceneCountInBuildSettings + " :(");
            return;
        }
        SceneManager.LoadScene(index);
    }
}
// Short delay before the player can interact with anything on screen (Delay ends when all initialization animation elements finish)
// Continue button will initilize last, allowing the player to read the instructions before continuing by accident