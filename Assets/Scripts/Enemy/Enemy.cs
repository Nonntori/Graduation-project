using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private Player _target;
    
    public event UnityAction Damaged;
    public event UnityAction Died;

    public Player Targer => _target;
    public int Health => _health;
    
    private Collider2D _collider2D;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Damaged?.Invoke();
        
        if (_health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Died?.Invoke();
        _collider2D.enabled = false;
        _rigidbody2D.isKinematic = true;
        enabled = false;
    }
}
