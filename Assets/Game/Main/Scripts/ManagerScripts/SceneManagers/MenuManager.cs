using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Build Settings indexes")] // Scenes
    [SerializeField] private int playSceneIndex = 2;
    [SerializeField] private int instructionsSceneIndex = 1;

    [Header("Play button animation")] // Play button animation, trigger for animation, and animation clip for length
    [SerializeField] private Animator playAnim;
    [SerializeField] private string playTrigger = "Play";
    [SerializeField] private AnimationClip playClip;

    [Header("How To Play button animation")] // same fields as Play button above, except for How To Play button
    [SerializeField] private Animator htpAnim;
    [SerializeField] private string htpTrigger = "HTP";
    [SerializeField] private AnimationClip htpClip;

    private bool isTransitioning = false; // prevents multiple button presses from triggering multiple scene loads

    public void OnPlayPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;

        StartCoroutine(PlayThenLoad(playAnim, playTrigger, playClip, playSceneIndex));
    }

    public void OnHowToPlayPressed()
    {
        if (isTransitioning) return;
        isTransitioning = true;

        StartCoroutine(PlayThenLoad(htpAnim, htpTrigger, htpClip, instructionsSceneIndex));
    }

    private IEnumerator PlayThenLoad(Animator anim, string trigger, AnimationClip clip, int sceneIndex) // Coroutines still confuse me a bit
    {
        if (anim != null)
        {
            anim.SetTrigger(trigger);

            if (clip != null)
            {
                // Clip length is adjusted for the state's speed multiplier
                yield return new WaitForSeconds(clip.length);
            }
        }

        LoadByIndex(sceneIndex);
    }

    private void LoadByIndex(int index) // Loading scene based off index in build settings
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