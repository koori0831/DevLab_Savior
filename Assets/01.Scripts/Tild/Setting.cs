using UnityEngine;
using Ami.BroAudio;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sFXSlider;

    public void SetMusicVolume(float volume)
    {
        BroAudio.SetVolume(BroAudioType.Music, volume);
    }
    public void SetSFXVolume(float volume)
    {
        BroAudio.SetVolume(BroAudioType.SFX,volume);
    }

}
