using UnityEngine;

public class Step1HandlerComponent :  MonoBehaviour, IStepHandler
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private MenuStepStateMachine MenuStepStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Next()
    {
        Disactive();
        var nextHandler = MenuStepStateMachine.Next();
        nextHandler.Active();
    }

    public void Active()
    {
        _panel.SetActive(true);
    }

    public void Disactive()
    {
        _panel.SetActive(false);
    }
}
