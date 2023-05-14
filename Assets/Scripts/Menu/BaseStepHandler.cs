using System;
using UnityEngine;

/// <summary>
/// ������� ����������� ���������� ���� ����
/// </summary>
public abstract class BaseStepHandler : MonoBehaviour
{
    [SerializeField] private MenuStepStateMachine menuStepStateMachine;

    /// <summary>
    /// ��������� ����
    /// </summary>
    public abstract void Active();

    /// <summary>
    /// ����������� ����
    /// </summary>
    public abstract void Disactive();

    /// <summary>
    /// ������� �������� � ���������� ���� ���� �� ��������
    /// </summary>
    public void Next()
    {
        var nextHandler = menuStepStateMachine.Next(this);
        Disactive();

        if (nextHandler != null)
            nextHandler.Active();
        else
            menuStepStateMachine.Finish();
    }
}
