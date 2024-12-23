using UnityEngine;

public class CardEquipCompo : MonoBehaviour
{
    [SerializeField] CardSO cardSO;
    [SerializeField] CardContainer cardContainer;
    [ContextMenu("Equip")]
    public void Equip()
    {
        cardContainer.AddCard(cardSO);
    }
}
