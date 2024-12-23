using System;
using System.Collections;
using UnityEngine;

public class ScreenWave : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] bool destroyOnEnd = true;
    int startTimeID = Shader.PropertyToID("_StartTime");
    int strengthID = Shader.PropertyToID("_Strength");
    int durationID = Shader.PropertyToID("_Duration");
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTimeID = Shader.PropertyToID("_StartTime");
        strengthID = Shader.PropertyToID("_Strength");
    }
    [SerializeField] float testStrength = 1;
    [SerializeField] float testDuration = 1;
    [ContextMenu("wave")]
    public void Wave()
    {
        StartShockWave(testStrength, testDuration);
    }
    public void StartShockWave(float strength, float duration)
    {
        spriteRenderer.material.SetFloat(startTimeID, Time.time);
        spriteRenderer.material.SetFloat(strengthID, strength * 0.1f);
        spriteRenderer.material.SetFloat(durationID, duration);
        if (destroyOnEnd)
            StartCoroutine(DestroyAfter(duration));
    }

    private IEnumerator DestroyAfter(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
