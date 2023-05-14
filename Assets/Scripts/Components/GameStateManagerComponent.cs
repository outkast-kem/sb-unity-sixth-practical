using Assets.Scripts.Components;
using System;
using UnityEngine;

/// <summary>
/// Компонент, управляющий состоянием игры (активна/неактивна)
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
    /// Метод запуска игры
    /// </summary>
    public void StartGame()
    {
        gameCanvas.gameObject.SetActive(true);

        OnGameStarted?.Invoke();
    }

    /// <summary>
    /// Метод окончания игры
    /// </summary>
    public void FinishGame(GameResults result)
    {
        OnGameFinished?.Invoke(result);
    }

    /// <summary>
    /// Активирует нужный canvas в зависимости от исхода игры
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
