using Assets.Scripts.Components;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������, ����������� ������� � ����������� ����
/// </summary>
public class ResultPanelComponent : MonoBehaviour
{
    [SerializeField] private ResultPanelTimerComponent resultTimerComponent;
    [SerializeField] private GameStateManagerComponent gameStateManager;
    [SerializeField] private GameObject textBackgroundPanel;

    private Image _textBackground;
    private GameResults _currentGameResult;

    private readonly Dictionary<GameResults, (string text, Color color)> _resultVisualDictionary = new()
    {
        [GameResults.Win] = ("� � � � � �", Color.yellow),
        [GameResults.Lose] = ("� � � � � � �", Color.red)
    };

    void Awake()
    {
        _textBackground = textBackgroundPanel.GetComponent<Image>();
    }

    void OnEnable()
    {
        gameStateManager.OnGameStarted += GameStateManager_OnGameStarted;
        gameStateManager.OnGameFinished += GameStateManager_OnGameFinished;

        resultTimerComponent.OnTimerEnded += Timer_OnTimerEnded;
    }

    public void OnDisable()
    {
        gameStateManager.OnGameStarted -= GameStateManager_OnGameStarted;
        gameStateManager.OnGameFinished -= GameStateManager_OnGameFinished;

        resultTimerComponent.OnTimerEnded -= Timer_OnTimerEnded;
    }

    /// <summary>
    /// ���������� ������� ��������� ����
    /// </summary>
    private void GameStateManager_OnGameFinished(GameResults args)
    {
        // � ����������� �� ������, ������������� ��������� ������ � ���������� � ��������� � ��������� ������

        _currentGameResult = args;

        var textComponent = _textBackground.GetComponentInChildren<Text>();

        textComponent.text = _resultVisualDictionary[args].text;
        textComponent.color = _resultVisualDictionary[args].color;

        _textBackground.gameObject.SetActive(true);

        resultTimerComponent.gameObject.SetActive(true);
    }

    /// <summary>
    /// ���������� ������� ������ ����
    /// </summary>
    private void GameStateManager_OnGameStarted()
    {
        _textBackground.gameObject.SetActive(false);
    }

    /// <summary>
    /// ���������� ������� ���������� ������� ������ ��������� � ����������� ����
    /// </summary>
    private void Timer_OnTimerEnded()
    {
        gameStateManager.GoToResultCanvas(_currentGameResult);
    }
}
