using UnityEngine;

public class ShockWavePlayer : MonoBehaviour
{
    [SerializeField] ScreenWave screenWavePref;
    [SerializeField] float strength = 1;
    [SerializeField] float duration = 1;
    public void Play()
    {
        ScreenWave screenWave = Instantiate(screenWavePref);
        screenWave.transform.position = transform.position;
        screenWave.StartShockWave(strength, duration);
    }
}
