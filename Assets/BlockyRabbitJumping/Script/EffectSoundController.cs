using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSoundController : MonoBehaviour
{
    public Sprite OnSound, MuteSound;
    public Image ImageButton;
    public AudioSource Jump, Fall;

    private bool isMute = false;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("Effect sound"))
        {
            ImageButton.sprite = OnSound;
        }

        if(PlayerPrefs.GetString("Effect sound") == "No")
        {
            Jump.mute = true;
            Fall.mute = true;
            ImageButton.sprite = MuteSound;
            isMute = true;
        }
        else
        {
            Jump.mute = false;
            Fall.mute = false;
            ImageButton.sprite = OnSound;
            isMute = false;
        }
    }

    public void SoundMute()
    {
        if (!isMute)
        {
            Jump.mute = true;
            Fall.mute = true;
            ImageButton.sprite = MuteSound;
            isMute = true;
        }
        else
        {
            Jump.mute = false;
            Fall.mute = false;
            ImageButton.sprite = OnSound;
            isMute = false;
        }
    }
}
