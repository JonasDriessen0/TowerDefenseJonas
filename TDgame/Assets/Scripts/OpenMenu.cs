using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OpenMenu : MonoBehaviour
{
    public RectTransform menuPanel;
    public RectTransform icon1;
    public RectTransform icon2;

    public Vector3 menuOpenScale = new Vector3(1f, 1f, 1f);
    public Vector3 menuOpenPosition = Vector3.zero;
    public Vector3 iconOpenScale = new Vector3(1f, 1f, 1f); // Scale for the icons when the menu is open
    public Vector3 iconOpenPosition1 = new Vector3(100f, 0f, 0f); // Target position for icon1 when menu is open
    public Vector3 iconOpenPosition2 = new Vector3(-100f, 0f, 0f); // Target position for icon2 when menu is open
    public float animationDuration = 1f;
    public Ease scaleEaseType = Ease.OutBack;
    public Ease positionEaseType = Ease.OutBack;

    private Vector3 initialMenuScale;
    private Vector3 initialMenuPosition;
    private Vector3 initialIconScale1;
    private Vector3 initialIconPosition1;
    private Vector3 initialIconScale2;
    private Vector3 initialIconPosition2;

    private bool isMenuOpen = false;

    private void Start()
    {
        initialMenuScale = menuPanel.localScale;
        initialMenuPosition = menuPanel.localPosition;
        initialIconScale1 = icon1.localScale;
        initialIconPosition1 = icon1.localPosition;
        initialIconScale2 = icon2.localScale;
        initialIconPosition2 = icon2.localPosition;
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
        menuPanel.localScale = initialMenuScale;
        menuPanel.localPosition = initialMenuPosition;
        icon1.localScale = initialIconScale1;
        icon1.localPosition = initialIconPosition1;
        icon2.localScale = initialIconScale2;
        icon2.localPosition = initialIconPosition2;

        menuPanel.DOScale(menuOpenScale, animationDuration).SetEase(scaleEaseType);
        menuPanel.DOLocalMove(menuOpenPosition, animationDuration).SetEase(positionEaseType);
        icon1.DOScale(iconOpenScale, animationDuration).SetEase(scaleEaseType);
        icon1.DOLocalMove(iconOpenPosition1, animationDuration).SetEase(positionEaseType);
        icon2.DOScale(iconOpenScale, animationDuration).SetEase(scaleEaseType);
        icon2.DOLocalMove(iconOpenPosition2, animationDuration).SetEase(positionEaseType);

        isMenuOpen = true;
    }

    public void Close()
    {
        menuPanel.DOScale(initialMenuScale, animationDuration).SetEase(scaleEaseType);
        menuPanel.DOLocalMove(initialMenuPosition, animationDuration).SetEase(positionEaseType);
        icon1.DOScale(initialIconScale1, animationDuration).SetEase(scaleEaseType);
        icon1.DOLocalMove(initialIconPosition1, animationDuration).SetEase(positionEaseType);
        icon2.DOScale(initialIconScale2, animationDuration).SetEase(scaleEaseType);
        icon2.DOLocalMove(initialIconPosition2, animationDuration).SetEase(positionEaseType);

        isMenuOpen = false;
    }
}
