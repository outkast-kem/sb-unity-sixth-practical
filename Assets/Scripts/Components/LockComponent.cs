using Assets.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент замка
/// </summary>
public class LockComponent : MonoBehaviour
{
    [SerializeField] private Text _firstPinText;
    [SerializeField] private Text _secondPinText;
    [SerializeField] private Text _thirdPinText;

    [SerializeField] private TimerComponent _timer;

    [SerializeField] private GameStateManagerComponent _gameStateManager;

    [SerializeField] private int _unlockValue;

    private Lock _lock;

    private void Awake()
    {
        _lock = new Lock(_unlockValue);
    }

    private void OnEnable()
    {
        Debug.Log("Lock is enabled");
        _gameStateManager.OnGameStarted += GameStateManager_OnGameStarted;
    }

    private void OnDisable()
    {
        Debug.Log("Lock is disabled");
        _gameStateManager.OnGameStarted -= GameStateManager_OnGameStarted;
    }

    private void GameStateManager_OnGameStarted()
    {
        var firstPinDefaultValue = 4;
        var secondPinDefaultValue = 7;
        var thirdPinDefaultValue = 5;

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
            _timer.DisableTimer();
            _gameStateManager.FinishGame(GameResults.Win);
        }
    }

    /// <summary>
    /// Обновляет текст пинов
    /// </summary>
    private void UpdatePins(Lock lockObject)
    {
        UpdatePinBlock(_firstPinText, lockObject.FirstPinCurrentValue);
        UpdatePinBlock(_secondPinText, lockObject.SecondPinCurrentValue);
        UpdatePinBlock(_thirdPinText, lockObject.ThirdPinCurrentValue);
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
