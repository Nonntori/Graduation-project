using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StateIdle : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(EnemyAnimatorController.States.Idle);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
