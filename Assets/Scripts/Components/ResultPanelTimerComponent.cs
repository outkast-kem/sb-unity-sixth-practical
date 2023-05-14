using System;
using UnityEngine;

/// <summary>
/// ������ ������� ��� ������ � ���������� � ���������� ����
/// </summary>
public class ResultPanelTimerComponent : MonoBehaviour
{
    /// <summary>
    /// ������������ ������ ��������� � ����������
    /// </summary>
    [SerializeField] private int timerDuration = 3;

    private float _timerSeconds;

    public event Action OnTimerEnded;

    private void OnEnable()
    {
        _timerSeconds = timerDuration;
    }

    private void Update()
    {
        _timerSeconds -= Time.deltaTime;

        if (_timerSeconds <= 0)
        {
            OnTimerEnded?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
