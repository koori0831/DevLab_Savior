using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private CinemachineCamera _virtualCamera;

    private void OnEnable()
    {
        Debug.Log("1");
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        _virtualCamera = FindAnyObjectByType<CinemachineCamera>();
    }

    public void ShakeCamera(float duration, float frequencyAmount, float AmplitudeAmount = 0.7f)
    {
        Debug.Log(_virtualCamera);
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
