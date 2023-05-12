using UnityEngine;

public class MenuStarterComponent : MonoBehaviour
{
    [SerializeField] MenuStepStateMachine _menuStepStateMachine;

    void Start()
    {
        var firstStep = _menuStepStateMachine.GetFirst();
        firstStep.Active();
    }
}
