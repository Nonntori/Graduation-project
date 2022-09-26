using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private int _coinCount = 0;
    private int _countCoinsToWin = 28;
    private int _currentHeath = 100;

    public int Health => _health;
    
    public event UnityAction<int,int> ChangingHealth;
    public event UnityAction<int> CoinCollected;
    public event UnityAction Died;
    public event UnityAction RaisedObject;
    public event UnityAction Damaged;
    public event UnityAction Won;

    private void Start()
    {
        _currentHeath = _health;
    }

    public void ApplyeDamage(int damage)
    {
        _currentHeath -= damage;
        ChangingHealth?.Invoke(_currentHeath,_health);
        Damaged?.Invoke();
        
        if (_currentHeath <= 0)
        {
            Die();
        }
    }

    public void TakeCoin()
    {
        _coinCount++;
        CoinCollected?.Invoke(_coinCount);
        RaisedObject?.Invoke();

        if (_coinCount == _countCoinsToWin)
        {
            Won?.Invoke();
        }
        
    }
    
    private void Die()
    {
        Died?.Invoke();
    }
}
