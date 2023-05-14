using System;
using UnityEngine;

/// <summary>
/// Базовый абстрактный обработчик шага меню
/// </summary>
public abstract class BaseStepHandler : MonoBehaviour
{
    [SerializeField] private MenuStepStateMachine menuStepStateMachine;

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
        var nextHandler = menuStepStateMachine.Next(this);
        Disactive();

        if (nextHandler != null)
            nextHandler.Active();
        else
            menuStepStateMachine.Finish();
    }
}
