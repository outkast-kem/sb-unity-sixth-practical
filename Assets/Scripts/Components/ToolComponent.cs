using Assets.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент кнопки инструмента
/// </summary>
public class ToolComponent : MonoBehaviour
{
    [SerializeField] private int _firstPin;
    [SerializeField] private int _secondPin;
    [SerializeField] private int _thirdPin;

    [SerializeField] private GameStateManagerComponent _gameStateManager;

    [SerializeField] Text _text;

    private Tool _tool;

    private void Awake()
    {
        _tool = new Tool(_firstPin, _secondPin, _thirdPin);
        _text.text = $"{_tool.FirstPinChangeValue:+#;-#;0} | {_tool.SecondPinChangeValue:+#;-#;0} | {_tool.ThirdPinChangeValue:+#;-#;0}";
    }

    private void OnEnable()
    {
        _gameStateManager.OnGameStarted += GameStateManager_OnGameStarted;
        _gameStateManager.OnGameFinished += GameStateManager_OnGameFinished;
    }

    private void OnDisable()
    {
        _gameStateManager.OnGameStarted -= GameStateManager_OnGameStarted;
        _gameStateManager.OnGameFinished -= GameStateManager_OnGameFinished;
    }

    private void GameStateManager_OnGameStarted()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }

    private void GameStateManager_OnGameFinished(GameResults gameResults)
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    /// <summary>
    /// Применяет значения инструмента к компоненту замку
    /// </summary>
    public void ApplyTool(LockComponent lockComponent)
    {
        lockComponent.ChangePins(_tool.FirstPinChangeValue, _tool.SecondPinChangeValue, _tool.ThirdPinChangeValue);
    }
}
