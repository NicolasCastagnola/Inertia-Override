using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public static UIManager Instance { get { return _instance; } }
    //private static UIManager _instance;
    
    [SerializeField] CanvasGroup deathPanel;
    [SerializeField] CanvasGroup victoryPanel;
    [SerializeField] Button buttonRespanFromCheckpoint;
    public bool hasCheckpointFlag = false;

    public TMP_Text newHighscoreValueDisplay;
    public bool newHighscoreValue = false;
    public TMP_Text currentPoints;
    public TMP_Text highscorePoints;

    #region MyFade
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

    #endregion

    public void ShowDeathScreen()
    {
        buttonRespanFromCheckpoint.gameObject.SetActive(hasCheckpointFlag);

        deathPanel.blocksRaycasts = true;
        Fade(deathPanel, 2f, true);
    }
    public void ShowVictoryScreen()
    {
        newHighscoreValueDisplay.gameObject.SetActive(newHighscoreValue);
        newHighscoreValueDisplay.text = $"NEW HIGH SCORE: {GameManager.Instance.currentPoints}";

        victoryPanel.blocksRaycasts = true;
        Fade(victoryPanel, 2f, true);
    }

    public void SetHighscoreFlagStatus(bool status)
    {
        newHighscoreValue = status;
    }
    public void GoToMenu()
    {
        SceneLoader.Instance.LoadLevel("Menu");
    }
    public void ReloadScene()
    {
        SceneLoader.Instance.LoadLevel("Main");
    }
    public void LoadFromCheckpoint()
    {

        StopAllCoroutines();

        Fade(deathPanel, 0.4f, false);

        EventManager.TriggerEvent(EventType.OnCheckpointLoaded);
    }

    public void RefreshCurrentPoints(int value)
    {
        currentPoints.text = value.ToString("000000000000");
    }
}


