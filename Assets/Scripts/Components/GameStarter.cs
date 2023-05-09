using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Canvas gameCanvas;

    public event Action OnGameStarted;

    public void StartGame()
    {
        gameCanvas.gameObject.SetActive(true);
        OnGameStarted?.Invoke();
    }
}
