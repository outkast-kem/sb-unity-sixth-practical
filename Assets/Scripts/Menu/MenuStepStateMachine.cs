using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ��������� ������ ��������� ��� ������� ����
/// </summary>
public class MenuStepStateMachine : MonoBehaviour
{
    [SerializeField] private BaseStepHandler firstStep;
    [SerializeField] private BaseStepHandler secondStep;

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameStateManagerComponent gameStarter;

    /// <summary>
    /// �������, ���������� ������� �������� ����� ��������
    /// </summary>
    private Dictionary<BaseStepHandler, BaseStepHandler> _stateMachine;

    void Awake()
    {
        Init();
    }

    /// <summary>
    /// ���������� ��� ����������� ���������� ���� ���� ��������� ���
    /// </summary>
    public BaseStepHandler Next(BaseStepHandler from)
    {
        return _stateMachine[from];
    }

    /// <summary>
    /// ���������� ������ ��� � ������ ���������
    /// </summary>
    public BaseStepHandler GetFirst()
    {
        return _stateMachine.Keys.Single(x => !_stateMachine.Values.Contains(x));
    }

    /// <summary>
    /// ���������� ��� ���������� ���������
    /// </summary>
    public void Finish()
    {
        menuCanvas.SetActive(false);

        gameStarter.StartGame();
    }

    /// <summary>
    /// ������������� ������� � ����������
    /// </summary>
    private void Init()
    {
        _stateMachine = new Dictionary<BaseStepHandler, BaseStepHandler>
        {
            [firstStep] = secondStep,
            [secondStep] = null
        };
    }
}
