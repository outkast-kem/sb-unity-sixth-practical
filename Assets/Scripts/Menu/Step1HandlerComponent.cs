using System;
using UnityEngine;

/// <summary>
/// ���������� ������� ���� ����
/// </summary>
public class Step1HandlerComponent : BaseStepHandler
{
    [SerializeField] private GameObject panel;

    /// <summary>
    /// ��������� ���� ����
    /// </summary>
    public override void Active()
    {
        panel.SetActive(true);
    }

    /// <summary>
    /// ����������� ���� ����
    /// </summary>
    public override void Disactive()
    {
        panel.SetActive(false);
    }
}
