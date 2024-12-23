using UnityEngine;

[CreateAssetMenu(menuName = "SO/Card/Type")]
public class CardTypeSO : ScriptableObject
{
    [SerializeField] public string typeName;
    [SerializeField] public Color cardBorderColor;
}
