using UnityEngine;

public class SpriteSlicePaticle : MonoBehaviour
{
    int columnID = Shader.PropertyToID("_Columns");
    int rowID = Shader.PropertyToID("_Rows");
    ParticleSystem particleCompo;
    Renderer rendererCompo;
    void Awake()
    {
        particleCompo = GetComponent<ParticleSystem>();
        rendererCompo = GetComponent<Renderer>();
    }
    public void InitPaticle(Texture2D texture2D, float column, float row)
    {
        rendererCompo.material = new Material(rendererCompo.material);
        rendererCompo.material.SetFloat(columnID, column);
        rendererCompo.material.SetFloat(rowID, row);
    }
}
