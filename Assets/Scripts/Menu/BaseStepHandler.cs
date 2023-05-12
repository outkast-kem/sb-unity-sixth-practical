using System;
using UnityEngine;

/// <summary>
/// Базовый абстрактный обработчик шага меню
/// </summary>
public abstract class BaseStepHandler : MonoBehaviour
{
    [SerializeField] private MenuStepStateMachine _menuStepStateMachine;

    private void Start()
    {
        if (_menuStepStateMachine == null) throw new ArgumentNullException(nameof(_menuStepStateMachine));
    }

    /// <summary>
    /// Активация шага
    /// </summary>
    public abstract void Active();

    /// <summary>
    /// Деактивация шага
    /// </summary>
    public abstract void Disactive();

    /// <summary>
    /// Функция перехода к следующему шагу меню от текущего
    /// </summary>
    public void Next()
    {
        var nextHandler = _menuStepStateMachine.Next(this);
        Disactive();

        if (nextHandler != null)
            nextHandler.Active();
        else
            _menuStepStateMachine.Finish();
    }
}
