using UnityEngine;

public class ItemSpriteController : MonoBehaviour
{
    [SerializeField] private Sprite _emptySprite;
    [SerializeField] private Sprite _redSprite;
    [SerializeField] private Sprite _successSprite;
    [SerializeField] private Sprite _nonSuccessSprite;

    public Sprite EmptySprite => _emptySprite;

    public Sprite RedSprite => _redSprite;

    public Sprite SuccessSprite => _successSprite;

    public Sprite NonSuccessSprite => _nonSuccessSprite;
}
