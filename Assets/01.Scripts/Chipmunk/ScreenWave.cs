using UnityEngine;

public class ScreenWave : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] string propertyName;
    int propertyId;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        propertyId = Shader.PropertyToID(propertyName);
    }
    [ContextMenu("wave")]
    public void Wave()
    {
        float time = Time.time;
        spriteRenderer.material.SetFloat(propertyId, time);
    }
}
