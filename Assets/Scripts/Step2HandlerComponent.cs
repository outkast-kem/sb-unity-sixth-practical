using UnityEngine;

public class Step2HandlerComponent : MonoBehaviour, IStepHandler
{
    [SerializeField] private GameObject _panel;

    // Start is called before the first frame update
    void Start()
    {
        
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

public interface IStepHandler
{
    void Active();

    void Disactive();
}
