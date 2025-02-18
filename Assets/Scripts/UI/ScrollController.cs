using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private float scrollStep = 0.1f; 

    private void Start()
    {
        downButton.onClick.AddListener(() => Scroll(-scrollStep));
        upButton.onClick.AddListener(() => Scroll(scrollStep));
    }

    private void Scroll(float amount)
    {
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition + amount);
    }
}
