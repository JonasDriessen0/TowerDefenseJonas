using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpenMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public Vector3 targetScale = new Vector3(1f, 1f, 1f);
    public Vector3 targetPosition = Vector3.zero;
    public float animationDuration = 1f;
    public Ease scaleEaseType = Ease.OutBack;
    public Ease positionEaseType = Ease.OutBack;

    private Vector3 initialScale;
    private Vector3 initialPosition;
    private bool isMenuOpen = false;

    private void Start()
    {
        initialScale = menuPanel.localScale;
        initialPosition = menuPanel.localPosition;
    }

    public void ToggleMenu()
    {
        if (isMenuOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        menuPanel.localScale = initialScale;
        menuPanel.localPosition = initialPosition;

        menuPanel.DOScale(targetScale, animationDuration).SetEase(scaleEaseType);
        menuPanel.DOLocalMove(targetPosition, animationDuration).SetEase(positionEaseType);

        isMenuOpen = true;
    }

    public void Close()
    {
        menuPanel.DOScale(initialScale, animationDuration).SetEase(scaleEaseType);
        menuPanel.DOLocalMove(initialPosition, animationDuration).SetEase(positionEaseType);

        isMenuOpen = false;
    }
}
