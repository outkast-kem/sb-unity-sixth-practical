using UnityEngine;
using UnityEngine.UI;

public class ToolComponent : MonoBehaviour
{
    [SerializeField] private int _firstPin;
    [SerializeField] private int _secondPin;
    [SerializeField] private int _thirdPin;

    [SerializeField] private GameStarter _gameStarter;

    [SerializeField] Text _text;

    private Tool _tool;

    private void Awake()
    {
        _tool = new Tool(_firstPin, _secondPin, _thirdPin);
        _text.text = $"{_tool.FirstPinChangeValue:+#;-#;0} | {_tool.SecondPinChangeValue:+#;-#;0} | {_tool.ThirdPinChangeValue:+#;-#;0}";
    }

    private void OnEnable()
    {
        _gameStarter.OnGameStarted += _gameStarter_OnGameStarted;
        _gameStarter.OnGameFinished += _gameStarter_OnGameFinished;
    }

    private void OnDisable()
    {
        _gameStarter.OnGameStarted -= _gameStarter_OnGameStarted;
        _gameStarter.OnGameFinished -= _gameStarter_OnGameFinished;
    }

    private void _gameStarter_OnGameStarted()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }

    private void _gameStarter_OnGameFinished()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void ApplyTool(LockComponent lockComponent)
    {
        lockComponent.ChangePins(_tool.FirstPinChangeValue, _tool.SecondPinChangeValue, _tool.ThirdPinChangeValue);
    }
}
