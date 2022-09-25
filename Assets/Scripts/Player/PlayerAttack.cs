using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _attackDelay = 1f;
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private float _hitRange = 0.5f;
    [SerializeField] private AudioSource _source;

    public event UnityAction Attacked;
    
    private bool _isAttacking;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    public void Attack()
    {
        if (!_isAttacking)
        {
            _isAttacking = true;

            if (_movement.Ground)
            {
                _source.Play();
                Attacked?.Invoke();
                StartCoroutine(Hit());
            }

            Invoke(nameof(AttackComplete), _attackDelay);
        }
    }

    private void AttackComplete()
    {
        StopCoroutine(Hit());
        _isAttacking = false;
    }

    private IEnumerator Hit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_hitPoint.position, _hitRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.TryGetComponent<Enemy>(out Enemy target))
            {
                target.TakeDamage(_damage);
            }
        }

        yield return null;
    }
}
