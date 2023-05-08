using UnityEngine;
using UnityEngine.UI;

public class ToolComponent : MonoBehaviour
{
    [SerializeField] private int _firstPin;
    [SerializeField] private int _secondPin;
    [SerializeField] private int _thirdPin;

    [SerializeField] Text _text;

    private Tool _tool;

    private void Awake()
    {
        _tool = new Tool(_firstPin, _secondPin, _thirdPin);
        _text.text = $"{_tool.FirstPinChangeValue:+#;-#;0} | {_tool.SecondPinChangeValue:+#;-#;0} | {_tool.ThirdPinChangeValue:+#;-#;0}";
    }

    public void ApplyTool(LockComponent lockComponent)
    {
        lockComponent.ChangePins(_tool.FirstPinChangeValue, _tool.SecondPinChangeValue, _tool.ThirdPinChangeValue);
    }
}
