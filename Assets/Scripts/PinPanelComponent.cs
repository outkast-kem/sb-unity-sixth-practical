using System;
using System.Linq;
using UnityEngine;

public class PinPanelComponent : MonoBehaviour
{
    [SerializeField] private LockComponent lockComponent;

    private PinItemComponent[] items = Array.Empty<PinItemComponent>();

    private void Start()
    {
        items = GetComponentsInChildren<PinItemComponent>();
    }

    public void UpdatePanel(int value)
    {
        var unlockValue = lockComponent.GetUnlockValue();
        var unlockItem = items.Single(x => x.Index == unlockValue);

        if (unlockValue == value)
            unlockItem.SetSuccessSprite();
        else
            unlockItem.SetNonSuccessSprite();

        var itemsToHide = items.Where(x => x.Index > value && x.Index != unlockValue);

        foreach (var item in itemsToHide)
            item.SetEmptySprite();

        var itemsToShow = items.Where(x => x.Index <= value && x.Index != unlockValue);

        foreach (var item in itemsToShow)
            item.SetRedSprite();
    }
}
