using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Text _percentegeText;
    [SerializeField] private  Slider _percentegeSlider;

    private static SceneLoader _instance;
    public static SceneLoader Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);
    }
    public void LoadLevel(string _sceneName)
    {
        StartCoroutine(LoadAsynchronus(_sceneName));
    }
    IEnumerator LoadAsynchronus(string _sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            _percentegeSlider.value = progress;
            _percentegeText.text = "Loading => " + (progress * 100f).ToString("0") + "%";

            yield return null;
        }

        _loadingScreen.SetActive(false);
    }
}
