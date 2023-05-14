using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Компонент машины состояний для экранов меню
/// </summary>
public class MenuStepStateMachine : MonoBehaviour
{
    [SerializeField] private BaseStepHandler firstStep;
    [SerializeField] private BaseStepHandler secondStep;

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameStateManagerComponent gameStarter;

    /// <summary>
    /// Словарь, содержащий простые переходы между экранами
    /// </summary>
    private Dictionary<BaseStepHandler, BaseStepHandler> _stateMachine;

    void Awake()
    {
        Init();
    }

    /// <summary>
    /// Возвращает для переданного компонента шага меню следующий шаг
    /// </summary>
    public BaseStepHandler Next(BaseStepHandler from)
    {
        return _stateMachine[from];
    }

    /// <summary>
    /// Возвращает первый шаг в машине состояний
    /// </summary>
    public BaseStepHandler GetFirst()
    {
        return _stateMachine.Keys.Single(x => !_stateMachine.Values.Contains(x));
    }

    /// <summary>
    /// Обработчик для завершения переходов
    /// </summary>
    public void Finish()
    {
        menuCanvas.SetActive(false);

        gameStarter.StartGame();
    }

    /// <summary>
    /// Инициализация словаря с переходами
    /// </summary>
    private void Init()
    {
        _stateMachine = new Dictionary<BaseStepHandler, BaseStepHandler>
        {
            [firstStep] = secondStep,
            [secondStep] = null
        };
    }
}
