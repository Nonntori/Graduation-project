using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement), typeof(PlayerAttack))]
[RequireComponent(typeof(Player),typeof(SpriteRenderer))]
public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private Color _damageСolor;
    
    private Animator _animator;
    private PlayerMovement _movement;
    private PlayerAttack _attack;
    private Player _player;
    private float _damageDeley = 0.5f;
    private SpriteRenderer _spritePlayer;
    private Color _defaulColorSprite = new Color(1f, 1f, 1f, 1f);
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        _attack = GetComponent<PlayerAttack>();
        _player = GetComponent<Player>();
        _spritePlayer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _movement.Run += OnRun;
        _movement.StopMoving += OnStopMoving;
        _movement.Jumped += OnJumped;
        _attack.Attacked += OnAttacked;
        _movement.Grounded += OnGround;
        _player.Died += OnDied;
        _player.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
        _movement.Run -= OnRun;
        _movement.StopMoving -= OnStopMoving;
        _movement.Jumped -= OnJumped;
        _attack.Attacked -= OnAttacked;
        _movement.Grounded -= OnGround;
        _player.Died -= OnDied;
        _player.Damaged -= OnDamaged;
    }

    private void OnRun()
    {
        _animator.SetFloat(PlayerAnimatorController.Params.Speed, _movement.Speed);
    }

    private void OnStopMoving()
    {
        _animator.SetFloat(PlayerAnimatorController.Params.Speed, 0);
    }

    private void OnGround()
    {
        _animator.SetTrigger(PlayerAnimatorController.States.Ground);
    }

    private void OnJumped()
    {
        _animator.SetTrigger(PlayerAnimatorController.States.Jump);
    }

    private void OnAttacked()
    {
        _animator.SetTrigger(PlayerAnimatorController.States.Attack);
    }

    private void OnDied()
    {
        _animator.SetTrigger(PlayerAnimatorController.States.Dead);
    }
    
    private void OnDamaged()
    {
        _spritePlayer.color = _damageСolor;
        Invoke(nameof(DamageComplete), _damageDeley);
    }

    private void DamageComplete()
    {
        _spritePlayer.color = _defaulColorSprite;
    }
}