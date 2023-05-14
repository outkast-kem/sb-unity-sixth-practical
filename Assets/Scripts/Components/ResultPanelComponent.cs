using Assets.Scripts.Components;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент, управляющий панелью с результатом игры
/// </summary>
public class ResultPanelComponent : MonoBehaviour
{
    [SerializeField] private ResultPanelTimerComponent _timer;
    [SerializeField] private GameStateManagerComponent _gameStateManager;
    [SerializeField] private GameObject _textBackgroundPanel;

    private Image _textBackground;

    private Dictionary<GameResults, (string text, Color color)> _resultVisualDictionary = new()
    {
        [GameResults.Win] = ("П О Б Е Д А", Color.yellow),
        [GameResults.Lose] = ("Н Е У Д А Ч А", Color.red)
    };

    void Awake()
    {
        _textBackground = _textBackgroundPanel.GetComponent<Image>();
    }

    void OnEnable()
    {
        _gameStateManager.OnGameStarted += GameStateManager_OnGameStarted;
        _gameStateManager.OnGameFinished += GameStateManager_OnGameFinished;
    }

    public void OnDisable()
    {
        _gameStateManager.OnGameStarted -= GameStateManager_OnGameStarted;
        _gameStateManager.OnGameFinished -= GameStateManager_OnGameFinished;
    }

    private void GameStateManager_OnGameFinished(GameResults args)
    {
        var textComponent = _textBackground.GetComponentInChildren<Text>();

        textComponent.text = _resultVisualDictionary[args].text;
        textComponent.color = _resultVisualDictionary[args].color;

        _textBackground.gameObject.SetActive(true);
    }

    private void GameStateManager_OnGameStarted()
    {
        _textBackground.gameObject.SetActive(false);
    }
}
