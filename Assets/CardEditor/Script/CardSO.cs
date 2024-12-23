using UnityEngine;

public abstract class CardSO : ScriptableObject
{
    [SerializeField] public Sprite cardIcon;
    [SerializeField] public string cardName;
    [SerializeField] public string cardDescription;
    public abstract void OnEquip(Player player);
    public virtual CardSO Clone()
    {
        return Instantiate(this);
    }
}
