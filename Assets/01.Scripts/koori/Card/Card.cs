using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private float transitionTime = 0.7f;
    private Vector3 _originScale;
    private RectTransform _rectTransform;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
       _originScale = transform.localScale;
    }

    public void SpawnCardAction(Transform targetTrm)
    {
        _rectTransform.position = new Vector3(targetTrm.position.x,targetTrm.position.y-150);
        float targetPosY = targetTrm.position.y;
        _rectTransform.DOMoveY(targetPosY, 1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("À±¿ÏÈñ ¸ÛÃ»ÀÌ");
        //Å¬¸¯ÇßÀ»¶§ ÀÌº¥Æ® ³Ö¾îÁÖ¼¼¿ä ÀÀ±ê
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
