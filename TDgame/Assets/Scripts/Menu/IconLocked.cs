using UnityEngine;
using UnityEngine.UI;

public class IconLocked : MonoBehaviour
{
    public bool isLocked = false;

    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    public Image iconImage;

    private void Start()
    {
        iconImage = GetComponent<Image>();
    }

    public void LockIcon()
    {
        iconImage.sprite = lockedSprite;
        iconImage.raycastTarget = false;
    }

    public void UnlockIcon()
    {
        iconImage.sprite = unlockedSprite;
        iconImage.raycastTarget = true;
    }
    private void Update()
    {
        if (isLocked)
        {
            LockIcon();
        }
        else
        {
            UnlockIcon();
        }
    }
}
