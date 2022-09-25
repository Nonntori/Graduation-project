using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public bool NeedTransition { get; protected set; }
    public State TargetState => _targetState;

    protected Player Target { get; private set; }

    private void OnEnable()
    {
        NeedTransition = false;
    }

    public void Initializing(Player target)
    {
        Target = target;
    }
}
