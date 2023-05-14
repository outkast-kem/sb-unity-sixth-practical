using UnityEngine;

/// <summary>
/// Стартовый компонент меню
/// </summary>
public class MenuStarterComponent : MonoBehaviour
{
    [SerializeField] MenuStepStateMachine menuStepStateMachine;

    void Start()
    {
        var firstStep = menuStepStateMachine.GetFirst();
        firstStep.Active();
    }
}
