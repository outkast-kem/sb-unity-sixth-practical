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

    public Lock(int unlockValue)
    {
        UnlockValue = unlockValue;
    }

    /// <summary>
    /// ������������� �������� ����� �� ��������� ��������
    /// </summary>
    public void SetupPins(int first, int second, int third)
    {
        FirstPinCurrentValue = first;
        SecondPinCurrentValue = second;
        ThirdPinCurrentValue = third;
    }

    /// <summary>
    /// ��������� � ������� ��������� ����� ���������� ��������
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
    /// ���������� ������� ����, ������ �� ������ ��� ���
    /// </summary>
    public bool IsOpen() => FirstPinCurrentValue == UnlockValue
        && SecondPinCurrentValue == UnlockValue
        && ThirdPinCurrentValue == UnlockValue;
}
