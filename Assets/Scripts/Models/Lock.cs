using System;
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

    /// <summary> Максимальное значение пина </summary>
    private int _maxPinValue = 10;

    /// <summary> Минимальное значение пина </summary>
    private int _minPinValue = 0;

    public Lock(int unlockValue)
    {
        UnlockValue = unlockValue;
    }

    /// <summary>
    /// Устанавливает значения пинов на указанные значения
    /// </summary>
    public void SetupPins(int first, int second, int third)
    {
        FirstPinCurrentValue = ValidatePinValue(first);
        SecondPinCurrentValue = ValidatePinValue(second);
        ThirdPinCurrentValue = ValidatePinValue(third);
    }

    /// <summary>
    /// Применяет к текущим значениям пинов переданные значения
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="third"></param>
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
    /// Возвращает признак того, открыт ли сундук или нет
    /// </summary>
    public bool IsOpen() => FirstPinCurrentValue == UnlockValue
        && SecondPinCurrentValue == UnlockValue
        && ThirdPinCurrentValue == UnlockValue;

    private int ValidatePinValue(int pinValue)
    {
        if (pinValue > _maxPinValue)
            return _maxPinValue;

        if (pinValue < _minPinValue)
            return _minPinValue;

        return pinValue;
    }
}
