using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Canvas gameCanvas;

    public bool IsGameActive { get; private set; }

    public event Action OnGameStarted;
    public event Action OnGameFinished;

    public void StartGame()
    {
        gameCanvas.gameObject.SetActive(true);
        IsGameActive = true;

        OnGameStarted?.Invoke();
    }

    public void FinishGame(bool result)
    {
        IsGameActive = false;

        OnGameFinished?.Invoke();
    }
}
