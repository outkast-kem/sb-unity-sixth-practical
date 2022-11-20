using UnityEngine;
using UnityEngine.UI;

public class TimerComponent : MonoBehaviour
{ 
    [SerializeField] private int playTime = 60;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private GameStarter _gameStarter;

    private bool isTimerEnabled;
    private float timerValue;

    private void Awake()
    {
        _gameStarter.OnGameStarted += GameStarter_OnGameStarted;
    }

    private void GameStarter_OnGameStarted()
    {
        Reset();
    }

    private void Update()
    {
        if (!isTimerEnabled)
            return;

        timerValue -= Time.deltaTime;

        var roundedTime = Mathf.Round(timerValue);
        timerText.text = roundedTime.ToString();

        if (roundedTime <= 0)
        {
            isTimerEnabled = false;
            losePanel.SetActive(true);
            return;
        }
    }

    private void Reset()
    {
        timerValue = playTime;
        timerText.text = timerValue.ToString();

        isTimerEnabled = true;
    }

    private void OnEnable()
    {
        Debug.Log("Timer is enabled");
        _gameStarter.OnGameStarted += GameStarter_OnGameStarted;
    }

    private void OnDisable()
    {
        Debug.Log("Timer is disabled");
        _gameStarter.OnGameStarted -= GameStarter_OnGameStarted;
    }

    public void DisableTimer()
    {
        isTimerEnabled = false;
    }
}