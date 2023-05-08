using System;
/// <summary>
/// ������ �����
/// </summary>
public class Lock
{
    /// <summary>�������� ������������� �����</summary>
    public int UnlockValue { get; }

    /// <summary>������� �������� ������� ����</summary>
    public int FirstPinCurrentValue { get; private set; }

    /// <summary>������� �������� ������� ����</summary>
    public int SecondPinCurrentValue { get; private set; }

    /// <summary>������� �������� �������� ����</summary>
    public int ThirdPinCurrentValue { get; private set; }

    /// <summary> ������������ �������� ���� </summary>
    private int _maxPinValue = 10;

    /// <summary> ����������� �������� ���� </summary>
    private int _minPinValue = 0;

    public Lock(int unlockValue)
    {
        UnlockValue = unlockValue;
    }

    /// <summary>
    /// ������������� �������� ����� �� ��������� ��������
    /// </summary>
    public void SetupPins(int first, int second, int third)
    {
        FirstPinCurrentValue = ValidatePinValue(first);
        SecondPinCurrentValue = ValidatePinValue(second);
        ThirdPinCurrentValue = ValidatePinValue(third);
    }

    /// <summary>
    /// ��������� � ������� ��������� ����� ���������� ��������
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
    /// ���������� ������� ����, ������ �� ������ ��� ���
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
