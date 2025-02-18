using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        canvasGroup.interactable = canvasGroup.blocksRaycasts = true;

        rectTransform.localScale = Vector3.zero;
        rectTransform.rotation = Quaternion.Euler(0, 0, 45);

        DOTween.Sequence()
            .Join(rectTransform.DOScale(1, 0.6f).SetEase(Ease.OutBack))
            .Join(rectTransform.DORotateQuaternion(Quaternion.identity, 0.6f))
            .Join(canvasGroup.DOFade(1, 0.6f).SetEase(Ease.OutCubic));
    }

    public void HidePopup()
    {
        rectTransform.DOKill();

        DOTween.Sequence()
            .Join(rectTransform.DORotateQuaternion(Quaternion.Euler(0, 0, 180), 0.3f))
            .Join(rectTransform.DOScale(0, 0.3f).SetEase(Ease.InBack))
            .Join(canvasGroup.DOFade(0, 0.3f).SetEase(Ease.InCubic))
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
                canvasGroup.interactable = canvasGroup.blocksRaycasts = false;


                rectTransform.rotation = Quaternion.identity;
                rectTransform.localScale = Vector3.one;

                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            });
    }
}
