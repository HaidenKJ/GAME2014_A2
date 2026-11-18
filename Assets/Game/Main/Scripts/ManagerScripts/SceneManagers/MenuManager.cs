using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Build Settings indexes")]
    [SerializeField] private int playSceneIndex = 2;
    [SerializeField] private int instructionsSceneIndex = 1;

    [Header("Play button animation")]
    [SerializeField] private Animator playAnim;
    [SerializeField] private string playTrigger = "Play";
    [SerializeField] private string playFinalState = "PlayTransition";

    [Header("How To Play button animation")]
    [SerializeField] private Animator htpAnim;
    [SerializeField] private string htpTrigger = "HTP";
    [SerializeField] private string htpFinalState = "HowToPlayTransition";

    [Header("Failsafe")]
    [SerializeField] private float timeoutSeconds = 5f;

    private bool isTransitioning = false;

    public void OnPlayPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;
        StartCoroutine(PlayAnimThenLoad(playAnim, playTrigger, playFinalState, playSceneIndex));
    }

    public void OnHowToPlayPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;
        StartCoroutine(PlayAnimThenLoad(htpAnim, htpTrigger, htpFinalState, instructionsSceneIndex));
    }

    private IEnumerator PlayAnimThenLoad(Animator anim, string trigger, string finalState, int sceneIndex)
    {
        if (anim == null)
        {
            Debug.LogError("MenuManager: Animator reference not assigned. Loading scene directly.", this);
            LoadByIndex(sceneIndex);
            yield break;
        }

        anim.SetTrigger(trigger);

        // 1) Wait until the Animator enters the final state
        float elapsed = 0f;
        while (!anim.GetCurrentAnimatorStateInfo(0).IsName(finalState))
        {
            elapsed += Time.unscaledDeltaTime;
            if (elapsed >= timeoutSeconds)
            {
                Debug.LogWarning("Never reached state '" + finalState + "'. Loading anyway.", this);
                LoadByIndex(sceneIndex);
                yield break;
            }
            yield return null;
        }

        // 2) Wait until the clip has played once
        while (anim.GetCurrentAnimatorStateInfo(0).IsName(finalState) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

        LoadByIndex(sceneIndex);
    }

    private void LoadByIndex(int index)
    {
        if (index < 0 || index >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Build index " + index + " is not in Build Settings. Scene count: " + SceneManager.sceneCountInBuildSettings);
            isTransitioning = false;
            return;
        }
        SceneManager.LoadScene(index);
    }
}