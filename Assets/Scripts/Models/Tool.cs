/// <summary>
/// ���������� ��� ��������� �������� �����
/// </summary>
public class Tool
{
    /// <summary> ��������, �� ������� �������� ������ ��� </summary>
    public int FirstPinChangeValue { get; }

    /// <summary> ��������, �� ������� �������� ������ ��� </summary>
    public int SecondPinChangeValue { get; }

    /// <summary> ��������, �� ������� �������� ������ ��� </summary>
    public int ThirdPinChangeValue { get; }

    /// <summary>
    /// ���������� ��� ��������� �������� �����
    /// </summary>
    public Tool(int firstPinChangeValue, int secondPinChangeValue, int thirdPinChangeValue)
    {
        FirstPinChangeValue = firstPinChangeValue;
        SecondPinChangeValue = secondPinChangeValue;
        ThirdPinChangeValue = thirdPinChangeValue;
    }
}
