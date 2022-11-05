/// <summary>
/// Модель замка
/// </summary>
public class Lock
{
    /// <summary>Значение разблокировки пинов</summary>
    public int UnlockValue { get; }

    /// <summary>Текущее значение первого пина</summary>
    public int FirstPinCurrentValue { get; private set; }

    /// <summary>Текущее значение второго пина</summary>
    public int SecondPinCurrentValue { get; private set; }

    /// <summary>Текущее значение третьего пина</summary>
    public int ThirdPinCurrentValue { get; private set; }

    public Lock(int unlockValue)
    {
        UnlockValue = unlockValue;
    }

    /// <summary>
    /// Устанавливает значения пинов на указанные значения
    /// </summary>
    public void SetupPins(int first, int second, int third)
    {
        FirstPinCurrentValue = first;
        SecondPinCurrentValue = second;
        ThirdPinCurrentValue = third;
    }

    /// <summary>
    /// Применяет к текущим значениям пинов переданные значения
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="third"></param>
    public void ApplyPinsChanges(int first, int second, int third)
    {
        FirstPinCurrentValue += first;
        SecondPinCurrentValue += second;
        ThirdPinCurrentValue += third;
    }

    /// <summary>
    /// Возвращает признак того, открыт ли сундук или нет
    /// </summary>
    public bool IsOpen() => FirstPinCurrentValue == UnlockValue
        && SecondPinCurrentValue == UnlockValue
        && ThirdPinCurrentValue == UnlockValue;
}
