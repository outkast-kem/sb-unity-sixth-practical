using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������� ������ ��������� ��� ������� ����
/// </summary>
public class MenuStepStateMachine : MonoBehaviour
{
    [SerializeField] private BaseStepHandler _firstStep;
    [SerializeField] private BaseStepHandler _secondStep;

    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameStarter _gameStarter;

    /// <summary>
    /// �������, ���������� ������� �������� ����� ��������
    /// </summary>
    private Dictionary<BaseStepHandler, BaseStepHandler> _stateMachine;

    void Start()
    {
        if (_firstStep == null) throw new ArgumentNullException(nameof(_firstStep));
        if (_secondStep == null) throw new ArgumentNullException(nameof(_secondStep));

        if (_menuCanvas == null) throw new ArgumentNullException(nameof(_menuCanvas));
        if (_gameStarter == null) throw new ArgumentNullException(nameof(_gameStarter));

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
    /// ���������� ��� ���������� ���������
    /// </summary>
    public void Finish()
    {
        Debug.Log("Finish state machine");

        _menuCanvas.SetActive(false);

        _gameStarter.StartGame();
    }

    /// <summary>
    /// ������������� ������� � ����������
    /// </summary>
    private void Init()
    {
        _stateMachine = new Dictionary<BaseStepHandler, BaseStepHandler>
        {
            [_firstStep] = _secondStep,
            [_secondStep] = null
        };
    }


}
