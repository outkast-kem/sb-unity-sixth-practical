using Assets.Scripts.Components;
using System;
using UnityEngine;

/// <summary>
/// ���������, ����������� ���������� ���� (�������/���������)
/// </summary>
public class GameStateManagerComponent : MonoBehaviour
{
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas loseCanvas;

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

    /// <summary>
    /// ���������� ������ canvas � ����������� �� ������ ����
    /// </summary>
    public void GoToResultCanvas(GameResults gameResult)
    {
        if (gameResult == GameResults.Win)
            winCanvas.gameObject.SetActive(true);
        else
            loseCanvas.gameObject.SetActive(true);

        gameCanvas.gameObject.SetActive(false);
    }
}
