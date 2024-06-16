using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerController : MonoBehaviour
{
    private static AudioPlayerController instance;
    public static AudioPlayerController Instance { get => instance; }

    [SerializeField] private AudioMixer mixer;

    public bool state = true;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void Toggle(bool state)
    {
        mixer.SetFloat("volume", state ? 0 : -80);
        this.state = state;
    }
}
