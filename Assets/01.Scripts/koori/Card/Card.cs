using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [Header("UI")]
    [SerializeField] private Image iconImage;
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI desTxt;


    [SerializeField] private BoolEventChannelSO chooseCardChannel;
    [SerializeField] private float transitionTime = 0.7f;
    private Vector3 _originScale;
    private RectTransform _rectTransform;

    private CardSO _cardSO;
    private CardContainer _cardContainer;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
       _originScale = transform.localScale;
    }

    public void Initialize(CardSO cardSO,CardContainer container)
    {
        _cardSO = cardSO;
        _cardContainer = container;


        iconImage.sprite = _cardSO.cardIcon;
        
        cardImage.material = _cardSO.cardType.cardMat;

        nameTxt.text = _cardSO.cardName;
        desTxt.text = _cardSO.cardDescription;
    }
    public void SpawnCardAction(Transform targetTrm)
    {
        float targetPosY = targetTrm.position.y;
        _rectTransform.position = new Vector3(targetTrm.position.x, targetPosY - 150);
        _rectTransform.DOMoveY(targetPosY, 1f);
    }

    public void DeleteCardAction()
    {
        _rectTransform.DOMoveY(_rectTransform.position.y + 150,1f).OnComplete(()=>Destroy(gameObject));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _cardContainer.AddCard(_cardSO);
        chooseCardChannel.RaiseEvent(true);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        DoScale(_originScale*1.2f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        DoScale(_originScale);
    }
    private void DoScale(Vector3 scale)=>
        _rectTransform.DOScale(scale, transitionTime);

   
}
