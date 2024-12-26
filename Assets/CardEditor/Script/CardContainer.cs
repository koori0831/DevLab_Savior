using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    [SerializeField] Player player;
    public List<CardSO> CardList { get; private set; } = new List<CardSO>();
    public void AddCard(CardSO card)
    {
        CardSO clonedCard = card.Clone();
        clonedCard.OnEquip(player);
        CardList.Add(clonedCard);
    }
    public void RemoveCard(CardSO card)
    {
        CardList.Remove(card);
    }
}
