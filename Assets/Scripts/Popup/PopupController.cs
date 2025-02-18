using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class PopupController : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText, subtitleText, buttonText;
    [SerializeField] private Button leftButton, rightButton, selectButton;
    [SerializeField] private Popup[] popups;

    private int currentIndex;
    private readonly PopupState[] states =
    {
        new PopupState("Добрый вечер", "Я диспетчер", "ВЫБРАТЬ"),
        new PopupState("Добрый вечер", "А что это значит?", "ВЫБРАТЬ")
    };

    private void Start()
    {
        leftButton.onClick.AddListener(() => ChangeState(-1));
        rightButton.onClick.AddListener(() => ChangeState(1));
        selectButton.onClick.AddListener(ShowNextPopup);

        AnimateButtons();
        UpdateUI();
    }

    private void ChangeState(int direction)
    {
        currentIndex = (currentIndex + direction + states.Length) % states.Length;
        UpdateUI();
    }

    private void UpdateUI()
    {
        AnimateText(titleText, states[currentIndex].Title);
        AnimateText(subtitleText, states[currentIndex].Subtitle);
        AnimateText(buttonText, states[currentIndex].ButtonText);
    }

    private void ShowNextPopup()
    {
        GetComponent<Popup>().HidePopup();
        if (currentIndex < popups.Length) popups[currentIndex].ShowPopup();
    }

    private void AnimateButtons()
    {
        float delay = 0;
        foreach (var button in new[] { leftButton, rightButton, selectButton })
        {
            button.transform.localScale = Vector3.zero;
            button.transform.DOScale(1, 0.3f).SetEase(Ease.OutBounce).SetDelay(delay);
            delay += 0.1f;
        }
    }

    private void AnimateText(TMP_Text text, string newText)
    {
        text.DOFade(0, 0.3f).OnComplete(() =>
        {
            text.text = newText;
            text.DOFade(1, 0.3f);
        });
    }
}
