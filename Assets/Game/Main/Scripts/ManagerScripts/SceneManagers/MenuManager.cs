using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Build Settings indexes")]
    [SerializeField] private int playSceneIndex = 1;   
    [SerializeField] private int instructionsSceneIndex = 2;  

    public void OnPlayPressed()
    {
        Debug.Log("Play pressed -> build index " + playSceneIndex);
        LoadByIndex(playSceneIndex);
    }

    public void OnHowToPlayPressed()
    {
        Debug.Log("How To Play pressed -> build index " + instructionsSceneIndex);
        LoadByIndex(instructionsSceneIndex);
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