using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get { return _instance; } }
    private static AudioManager _instance;

    [SerializeField] AudioSource music;
    [SerializeField] public List<AudioSource> bossSounds;
    [SerializeField] public List<AudioSource> playerSounds;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;
    }
}
