using Assets.Scripts.Components;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент кнопки инструмента
/// </summary>
public class ToolComponent : MonoBehaviour
{
    [SerializeField] private int firstPin;
    [SerializeField] private int secondPin;
    [SerializeField] private int thirdPin;

    [SerializeField] private GameStateManagerComponent gameStateManager;

    [SerializeField] Text text;

    private Tool _tool;

    private void Awake()
    {
        _tool = new Tool(firstPin, secondPin, thirdPin);
        text.text = $"{_tool.FirstPinChangeValue:+#;-#;0} | {_tool.SecondPinChangeValue:+#;-#;0} | {_tool.ThirdPinChangeValue:+#;-#;0}";
    }

    private void OnEnable()
    {
        gameStateManager.OnGameStarted += GameStateManager_OnGameStarted;
        gameStateManager.OnGameFinished += GameStateManager_OnGameFinished;
    }

    private void OnDisable()
    {
        gameStateManager.OnGameStarted -= GameStateManager_OnGameStarted;
        gameStateManager.OnGameFinished -= GameStateManager_OnGameFinished;
    }

    /// <summary>
    /// Обработчик события начала игры
    /// </summary>
    private void GameStateManager_OnGameStarted()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }

    /// <summary>
    /// Обработчик события завершения игры
    /// </summary>
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
