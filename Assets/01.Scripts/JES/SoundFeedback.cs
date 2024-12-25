using Ami.BroAudio;
using UnityEngine;

public class SoundFeedback : Feedback
{
    [SerializeField] private SoundID soundID;
    public override void PlayFeedback()
    {
        BroAudio.Play(soundID);
    }

    public override void StopFeedback()
    {
        BroAudio.Stop(soundID);
    }
}
