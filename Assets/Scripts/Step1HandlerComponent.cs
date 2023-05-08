using System;
using UnityEngine;

/// <summary>
/// ���������� ������� ���� ����
/// </summary>
public class Step1HandlerComponent : BaseStepHandler
{
    [SerializeField] private GameObject _panel;

    void Start()
    {
        if (_panel == null) throw new ArgumentNullException(nameof(_panel));
    }

    /// <summary>
    /// ��������� ���� ����
    /// </summary>
    public override void Active()
    {
        _panel.SetActive(true);
    }

    /// <summary>
    /// ����������� ���� ����
    /// </summary>
    public override void Disactive()
    {
        _panel.SetActive(false);
    }
}
