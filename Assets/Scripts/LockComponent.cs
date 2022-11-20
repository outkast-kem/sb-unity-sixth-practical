using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class LockComponent : MonoBehaviour
{
    //[SerializeField] private Text _firstPinText;
    //[SerializeField] private Text _secondPinText;
    //[SerializeField] private Text _thirdPinText;

    [SerializeField] private PinPanelComponent _firstPinPanel;
    [SerializeField] private PinPanelComponent _secondPinPanel;
    [SerializeField] private PinPanelComponent _thirdPinPanel;

    [SerializeField] private TimerComponent _timer;
    [SerializeField] private GameObject _winCanvas;

    [SerializeField] private GameStarter _gameStarter;

    [SerializeField] private int _unlockValue;

    private Lock _lock;

    private void Awake()
    {
        _lock = new Lock(_unlockValue);
    }

    private void GameStarter_OnGameStarted()
    {
        var rnd = new Random();

        var firstPinDefaultValue = 4; // GetRandomValue();
        var secondPinDefaultValue = 7; // GetRandomValue();
        var thirdPinDefaultValue = 5; // GetRandomValue();

        _lock.SetupPins(firstPinDefaultValue, secondPinDefaultValue, thirdPinDefaultValue);

        UpdatePins(_lock);

        int GetRandomValue() => rnd.Next(0, 10);
    }

    private void OnEnable()
    {
        Debug.Log("Lock is enabled");
        _gameStarter.OnGameStarted += GameStarter_OnGameStarted;
    }

    private void OnDisable()
    {
        Debug.Log("Lock is disabled");
        _gameStarter.OnGameStarted -= GameStarter_OnGameStarted;
    }

    public void ChangePins(int firstPinChanges, int secondPinChanges, int thirdPinChanges)
    {
        _lock.ApplyPinsChanges(firstPinChanges, secondPinChanges, thirdPinChanges);
        UpdatePins(_lock);

        if (_lock.IsOpen())
        {
            _timer.DisableTimer();
            _winCanvas.SetActive(true);
        }
    }

    public int GetUnlockValue() => _lock.UnlockValue;

    private void UpdatePins(Lock lockObject)
    {
        UpdatePinPanel(_firstPinPanel, lockObject.FirstPinCurrentValue);
        UpdatePinPanel(_secondPinPanel, lockObject.SecondPinCurrentValue);
        UpdatePinPanel(_thirdPinPanel, lockObject.ThirdPinCurrentValue);
    }

    private void UpdatePinPanel(PinPanelComponent pinPanel, int pinValue)
    {
        pinPanel.UpdatePanel(pinValue);
    }

    //private void UpdatePins(Lock lockObject)
    //{
    //    UpdatePinBlock(_firstPinText, lockObject.FirstPinCurrentValue);
    //    UpdatePinBlock(_secondPinText, lockObject.SecondPinCurrentValue);
    //    UpdatePinBlock(_thirdPinText, lockObject.ThirdPinCurrentValue);
    //}

    private void UpdatePinBlock(Text text, int currentValue)
    {
        text.text = currentValue.ToString();
        text.color = GetColor(currentValue);
    }

    private Color GetColor(int currentValue)
    {
        if (currentValue < _lock.UnlockValue)
            return Color.red;

        if (currentValue > _lock.UnlockValue)
            return Color.blue;

        return Color.green;
    }
}
