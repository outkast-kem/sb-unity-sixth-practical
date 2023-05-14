/// <summary>
/// Инструмент для изменения значений пинов
/// </summary>
public class Tool
{
    /// <summary> Значение, на которое меняется первый пин </summary>
    public int FirstPinChangeValue { get; }

    /// <summary> Значение, на которое меняется второй пин </summary>
    public int SecondPinChangeValue { get; }

    /// <summary> Значение, на которое меняется третий пин </summary>
    public int ThirdPinChangeValue { get; }

    /// <summary>
    /// Инструмент для изменения значений пинов
    /// </summary>
    public Tool(int firstPinChangeValue, int secondPinChangeValue, int thirdPinChangeValue)
    {
        FirstPinChangeValue = firstPinChangeValue;
        SecondPinChangeValue = secondPinChangeValue;
        ThirdPinChangeValue = thirdPinChangeValue;
    }
}
