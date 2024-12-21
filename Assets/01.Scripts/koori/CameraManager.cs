using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _virtualCamera;

    public void ShakeCamera(float duration, float frequencyAmount, float AmplitudeAmount = 0.7f)
    {
        StartCoroutine(CamShake(duration, frequencyAmount, AmplitudeAmount));
    }
    private IEnumerator CamShake(float duration, float frequencyAmount, float AmplitudeAmount)
    {
        CinemachineBasicMultiChannelPerlin vCam = _virtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        vCam.FrequencyGain = frequencyAmount;
        vCam.AmplitudeGain = AmplitudeAmount;
        yield return new WaitForSeconds(duration);
        vCam.FrequencyGain = 0;
        vCam.AmplitudeGain = 0;
    }
}
