using UnityEngine;

public class MenuStepStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] _steps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IStepHandler Next()
    {
        return null;
    }
}
