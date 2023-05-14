using Assets.Scripts.Components;
using System;
using UnityEngine;

/// <summary>
/// ���������, ����������� ���������� ���� (�������/���������)
/// </summary>
public class GameStateManagerComponent : MonoBehaviour
{
    [SerializeField] private Canvas gameCanvas;

    public bool IsGameActive { get; private set; }

    public delegate void GameFinishHandler(GameResults args);

    public event Action OnGameStarted;
    public event GameFinishHandler OnGameFinished;

    /// <summary>
    /// ����� ������� ����
    /// </summary>
    public void StartGame()
    {
        gameCanvas.gameObject.SetActive(true);

        OnGameStarted?.Invoke();
    }

    /// <summary>
    /// ����� ��������� ����
    /// </summary>
    public void FinishGame(GameResults result)
    {
        OnGameFinished?.Invoke(result);
    }
}
