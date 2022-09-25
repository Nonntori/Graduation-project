using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;
    private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Died += OnDied;
        Reset(_firstState);
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transition(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_enemy.Targer);
        }
    }

    private void Transition(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_enemy.Targer);
        }
    }

    private void OnDied()
    {
        DisableStateMachine();
    }
    
    private void DisableStateMachine()
    {
        _currentState.Exit();
        enabled = false;
    }
}
