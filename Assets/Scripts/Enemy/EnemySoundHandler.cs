using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemySoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _damageSound;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
        _enemy.Damaged -= OnDamaged;
    }

    private void OnDamaged()
    {
        _damageSound.Play();
    }
}
