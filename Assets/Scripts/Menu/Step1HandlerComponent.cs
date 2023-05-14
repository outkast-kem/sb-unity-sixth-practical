using System;
using UnityEngine;

/// <summary>
/// Обработчик первого шага меню
/// </summary>
public class Step1HandlerComponent : BaseStepHandler
{
    [SerializeField] private GameObject panel;

    /// <summary>
    /// Активация шага меню
    /// </summary>
    public override void Active()
    {
        panel.SetActive(true);
    }

    /// <summary>
    /// Деактивация шага меню
    /// </summary>
    public override void Disactive()
    {
        panel.SetActive(false);
    }
}
