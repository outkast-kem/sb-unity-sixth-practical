using UnityEngine;

public class ResultPanelComponent : MonoBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameStarter _gameStarter;

    void Awake()
    {
        _gameStarter.OnGameStarted += _gameStarter_OnGameStarted;
    }

    private void _gameStarter_OnGameStarted()
    {
        _resultPanel.SetActive(false);
    }
}
