using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StateAttack : State
{
    [SerializeField] private int _damage = 50;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private float _hitRange;

    public event UnityAction Attacked;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            StartCoroutine(Hit());
            _lastAttackTime = _delay;
            Attacked?.Invoke();
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private IEnumerator Hit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_hitPoint.position, _hitRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.TryGetComponent<Player>(out Player target))
            {
                target.ApplyeDamage(_damage);
            }
        }

        yield return null;
    }
}
