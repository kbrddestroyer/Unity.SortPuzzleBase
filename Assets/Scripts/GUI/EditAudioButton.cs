using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditAudioButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;


    public void ToggleSFXState()
    {
        AudioPlayerController.Instance.Toggle(
            !AudioPlayerController.Instance.state
            );

        image.sprite = AudioPlayerController.Instance.state ? on : off;
    }
}
