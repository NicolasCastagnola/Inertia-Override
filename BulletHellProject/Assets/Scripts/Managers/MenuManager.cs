using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] CanvasGroup panel;

    [SerializeField] AudioSource tickSound;

    private void Start()
    {
        Fade(panel, 3f, true);
    }
    public void GoToGame()
    {
        SceneLoader.Instance.LoadLevel("Main");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        controlsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void Options()
    {
        mainPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
    public void Fade(CanvasGroup canvas, float timeSpan, bool fadeIn)
    {
        StartCoroutine(DoFade(canvas, canvas.alpha, fadeIn ? 1 : 0, timeSpan));
    }
    private IEnumerator DoFade(CanvasGroup canvasGroup, float s, float e, float duration)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(s, e, timer / duration);

            yield return null;
        }
    }
}
