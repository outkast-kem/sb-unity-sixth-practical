/// <summary>
/// ћодель замка
/// </summary>
public class Lock
{
    /// <summary>«начение разблокировки пинов</summary>
    public int UnlockValue { get; }

    /// <summary>“екущее значение первого пина</summary>
    public int FirstPinCurrentValue { get; private set; }

    /// <summary>“екущее значение второго пина</summary>
    public int SecondPinCurrentValue { get; private set; }

    /// <summary>“екущее значение третьего пина</summary>
    public int ThirdPinCurrentValue { get; private set; }

    /// <summary> ћаксимальное значение пина </summary>
    private const int MaxPinValue = 10;

    /// <summary> ћинимальное значение пина </summary>
    private const int MinPinValue = 0;

    /// <summary>
    /// ћодель замка
    /// </summary>
    /// <param name="unlockValue">«начение, при котором замок считаетс€ открытым</param>
    public Lock(int unlockValue)
    {
        UnlockValue = unlockValue;
    }

    /// <summary>
    /// ”станавливает значени€ пинов на указанные значени€
    /// </summary>
    public void SetupPins(int first, int second, int third)
    {
        FirstPinCurrentValue = ValidatePinValue(first);
        SecondPinCurrentValue = ValidatePinValue(second);
        ThirdPinCurrentValue = ValidatePinValue(third);
    }

    /// <summary>
    /// ѕримен€ет к текущим значени€м пинов переданные значени€
    /// </summary>
    public void ApplyPinsChanges(int first, int second, int third)
    {
        var newFirstPinValue = ValidatePinValue(FirstPinCurrentValue + first);
        var newSecondPinValue = ValidatePinValue(SecondPinCurrentValue + second);
        var newThirdPinValue = ValidatePinValue(ThirdPinCurrentValue + third);

        FirstPinCurrentValue = newFirstPinValue;
        SecondPinCurrentValue = newSecondPinValue;
        ThirdPinCurrentValue = newThirdPinValue;
    }

    /// <summary>
    /// ¬озвращает признак того, открыт ли сундук или нет
    /// </summary>
    public bool IsOpen() => FirstPinCurrentValue == UnlockValue && 
                            SecondPinCurrentValue == UnlockValue && 
                            ThirdPinCurrentValue == UnlockValue;

    /// <summary>
    /// ћетод, провер€ющий значение пина
    /// </summary>
    private int ValidatePinValue(int pinValue)
    {
        // если полученное значение выше максимального или ниже минимального, то значению ставитс€ соответственно
        // максимально или минимально возможное значение  

        if (pinValue > MaxPinValue)
            return MaxPinValue;

        if (pinValue < MinPinValue)
            return MinPinValue;

        return pinValue;
    }
}
