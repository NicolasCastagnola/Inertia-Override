using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMuteTargetAudioSource : MonoBehaviour
{
    [SerializeField] private List<AudioSource> audioSource;
    [SerializeField] private Sprite onImage;
    [SerializeField] private Sprite offImage;

    private bool muted;

    public void OnClick()
    {
        muted = !muted;

        gameObject.GetComponent<Image>().sprite = muted ? offImage : onImage;

        foreach (var audioSources in audioSource)
        {
            audioSources.volume = muted ? 0 : 0.8f;
        }
    }
}
