using System;
using UnityEngine;

/// <summary>
/// Обработчик второго шага меню
/// </summary>
public class Step2HandlerComponent : BaseStepHandler
{
    [SerializeField] private GameObject _panel;

    void Start()
    {
        if (_panel == null) throw new ArgumentNullException(nameof(_panel));
    }

    /// <summary>
    /// Активация шага меню
    /// </summary>
    public override void Active()
    {
        _panel.SetActive(true);
    }

    /// <summary>
    /// Деактивация шага меню
    /// </summary>
    public override void Disactive()
    {
        _panel.SetActive(false);
    }
}
