using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator), typeof(StatePatrol), typeof(StateAttack))]
public class EnemyAnimationHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject _hitParticle;
    [SerializeField] private Color _damageСolor;
    
    private StatePatrol _statePatrol;
    private StateAttack _stateAttack;
    private float _damageDelay = 0.5f;
    private Animator _animator;
    private SpriteRenderer _spriteEnemy;
    private Color _defaulColorSprite = new Color(1f, 1f, 1f, 1f);

    private void Awake()
    {
        _spriteEnemy = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _statePatrol = GetComponent<StatePatrol>();
        _stateAttack = GetComponent<StateAttack>();
    }

    private void OnEnable()
    {
        _statePatrol.Walk += OnWalk;
        _stateAttack.Attacked += OnStateAttack;
        _enemy.Damaged += OnDamaged;
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _statePatrol.Walk -= OnWalk;
        _stateAttack.Attacked -= OnStateAttack;
        _enemy.Damaged -= OnDamaged;
        _enemy.Died -= OnDied;
    }

    private void OnStateAttack()
    {
        _animator.Play(EnemyAnimatorController.States.Attack);
    }

    private void OnWalk()
    {
        _animator.Play(EnemyAnimatorController.States.Walk);
    }

    private void OnDamaged()
    {
        _spriteEnemy.color = _damageСolor;
        Instantiate(_hitParticle, transform.position, Quaternion.identity);
        Invoke(nameof(DamageComplete), _damageDelay);
    }

    private void DamageComplete()
    {
        _spriteEnemy.color = _defaulColorSprite;
    }

    private void OnDied()
    {
        _animator.Play(EnemyAnimatorController.States.Dead);
    }
}
