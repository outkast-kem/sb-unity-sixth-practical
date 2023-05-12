using System;
using UnityEngine;

/// <summary>
/// ������� ����������� ���������� ���� ����
/// </summary>
public abstract class BaseStepHandler : MonoBehaviour
{
    [SerializeField] private MenuStepStateMachine _menuStepStateMachine;

    private void Start()
    {
        if (_menuStepStateMachine == null) throw new ArgumentNullException(nameof(_menuStepStateMachine));
    }

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
        var nextHandler = _menuStepStateMachine.Next(this);
        Disactive();

        if (nextHandler != null)
            nextHandler.Active();
        else
            _menuStepStateMachine.Finish();
    }
}
