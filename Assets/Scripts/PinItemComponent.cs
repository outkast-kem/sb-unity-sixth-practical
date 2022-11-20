using UnityEngine;
using UnityEngine.UI;

public class PinItemComponent : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private ItemSpriteController spriteController;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public int Index => index;

    public void SetEmptySprite()
    {
        _image.overrideSprite = spriteController.EmptySprite;
    }

    public void SetSuccessSprite()
    {
        _image.overrideSprite = spriteController.SuccessSprite;
    }

    public void SetNonSuccessSprite()
    {
        _image.overrideSprite = spriteController.NonSuccessSprite;
    }

    public void SetRedSprite()
    {
        _image.overrideSprite = spriteController.RedSprite;
    }
}
