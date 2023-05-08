using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Canvas startGameCanvas;
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas loseCanvas;

    public event Action OnGameStarted;

    private void Start()
    {
        //startGameCanvas.gameObject.SetActive(true);
        //gameCanvas.gameObject.SetActive(false);
        //winCanvas.gameObject.SetActive(false);
        //loseCanvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        gameCanvas.gameObject.SetActive(true);
        OnGameStarted?.Invoke();
    }
}
