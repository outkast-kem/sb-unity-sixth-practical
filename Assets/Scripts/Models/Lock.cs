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
    private const int MaxPinValue = 10;

    /// <summary> ����������� �������� ���� </summary>
    private const int MinPinValue = 0;

    /// <summary>
    /// ������ �����
    /// </summary>
    /// <param name="unlockValue">��������, ��� ������� ����� ��������� ��������</param>
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
    public bool IsOpen() => FirstPinCurrentValue == UnlockValue && 
                            SecondPinCurrentValue == UnlockValue && 
                            ThirdPinCurrentValue == UnlockValue;

    /// <summary>
    /// �����, ����������� �������� ����
    /// </summary>
    private int ValidatePinValue(int pinValue)
    {
        // ���� ���������� �������� ���� ������������� ��� ���� ������������, �� �������� �������� ��������������
        // ����������� ��� ���������� ��������� ��������  

        if (pinValue > MaxPinValue)
            return MaxPinValue;

        if (pinValue < MinPinValue)
            return MinPinValue;

        return pinValue;
    }
}
