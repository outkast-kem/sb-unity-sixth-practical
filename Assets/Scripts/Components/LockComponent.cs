using Assets.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент замка
/// </summary>
public class LockComponent : MonoBehaviour
{
    [SerializeField] private Text firstPinText;
    [SerializeField] private Text secondPinText;
    [SerializeField] private Text thirdPinText;

    [SerializeField] private TimerComponent timerComponent;

    [SerializeField] private GameStateManagerComponent gameStateManager;

    /// <summary>
    /// Значение для открытия замка
    /// </summary>
    [SerializeField] private int unlockValue = 5;

    private Lock _lock;

    private void Awake()
    {
        _lock = new Lock(unlockValue);
    }

    private void OnEnable()
    {
        Debug.Log("Lock is enabled");
        gameStateManager.OnGameStarted += GameStateManager_OnGameStarted;
    }

    private void OnDisable()
    {
        Debug.Log("Lock is disabled");
        gameStateManager.OnGameStarted -= GameStateManager_OnGameStarted;
    }

    /// <summary>
    /// Обработка события начала игры
    /// </summary>
    private void GameStateManager_OnGameStarted()
    {
        var firstPinDefaultValue = 3;
        var secondPinDefaultValue = 8;
        var thirdPinDefaultValue = 6;

        _lock.SetupPins(firstPinDefaultValue, secondPinDefaultValue, thirdPinDefaultValue);

        UpdatePins(_lock);
    }

    /// <summary>
    /// Применяет значения пинов к замку
    /// </summary>
    public void ChangePins(int firstPinChanges, int secondPinChanges, int thirdPinChanges)
    {
        _lock.ApplyPinsChanges(firstPinChanges, secondPinChanges, thirdPinChanges);
        UpdatePins(_lock);

        if (_lock.IsOpen())
        {
            timerComponent.DisableTimer();
            gameStateManager.FinishGame(GameResults.Win);
        }
    }

    /// <summary>
    /// Обновляет текст пинов
    /// </summary>
    private void UpdatePins(Lock lockObject)
    {
        UpdatePinBlock(firstPinText, lockObject.FirstPinCurrentValue);
        UpdatePinBlock(secondPinText, lockObject.SecondPinCurrentValue);
        UpdatePinBlock(thirdPinText, lockObject.ThirdPinCurrentValue);
    }

    private void UpdatePinBlock(Text text, int currentValue)
    {
        text.text = currentValue.ToString();
        text.color = GetColor(currentValue);
    }

    private Color GetColor(int currentValue)
    {
        if (currentValue < _lock.UnlockValue)
            return Color.red;

        if (currentValue > _lock.UnlockValue)
            return Color.blue;

        return Color.green;
    }
}
