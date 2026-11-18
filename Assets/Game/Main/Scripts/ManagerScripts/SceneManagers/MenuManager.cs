using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private string playSceneName = "LevelSelect";
    [SerializeField] private string instructionsSceneName = "Instructions";

    [Header("Timing")]
    [Tooltip("Total length of the Play_HalfFull + TextReposition clips (or HTP equivalents).")]
    [SerializeField] private float transitionDelay = 1.0f;

    [Header("Animator (auto-found if left empty)")]
    [SerializeField] private Animator anim;

    private bool isTransitioning = false;

    private static readonly int PlayHash = Animator.StringToHash("Play");
    private static readonly int HtpHash = Animator.StringToHash("HTP");

    private void Awake()
    {
        if (anim == null) anim = GetComponent<Animator>();
        if (anim == null) anim = GetComponentInChildren<Animator>();

        if (anim == null)
            Debug.LogError("MenuManager: no Animator found on " + name);
    }

    // Hook to the Play button's OnClick()
    public void OnPlayPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;

        Debug.Log("Play button pressed. Transitioning to scene: " + playSceneName);

        anim.ResetTrigger(HtpHash);
        anim.SetTrigger(PlayHash);

        // StartCoroutine(LoadSceneAfterDelay(playSceneName));
    }

    // Hook to the How To Play button's OnClick()
    public void OnHowToPlayPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;

        Debug.Log("How To Play pressed. Transitioning to scene: " + instructionsSceneName);

        anim.ResetTrigger(PlayHash);
        anim.SetTrigger(HtpHash);

        // StartCoroutine(LoadSceneAfterDelay(instructionsSceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(sceneName);
    }
}