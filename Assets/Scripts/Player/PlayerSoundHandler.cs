using UnityEngine;

[RequireComponent(typeof(PlayerAttack), typeof(PlayerMovement), typeof(Player))]
public class PlayerSoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _walkSound;
    [SerializeField] private AudioSource _coinSound;
    
    private PlayerAttack _playerAttack;
    private PlayerMovement _playerMovement;
    private Player _player;

    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerMovement = GetComponent<PlayerMovement>();
        _player = GetComponent<Player>();
    }
    
    private void FixedUpdate()
    {
        Run();
    }

    private void OnEnable()
    {
        _playerAttack.Attacked += OnAttacked;
        _playerMovement.Jumped += OnJumped;
        _player.Died += OnDied;
        _player.RaisedObject += OnRaisedObject;
    }

    private void OnDisable()
    {
        _playerAttack.Attacked -= OnAttacked;
        _playerMovement.Jumped -= OnJumped;
        _playerMovement.StopMoving += OnStopMove;
        _player.Died -= OnDied;
        _player.RaisedObject -= OnRaisedObject;
    }
    
    private void OnJumped()
    {
        _jumpSound.Play();
    }
    
    private void Run()
    {
        if (_playerMovement.Ground)
        {
            if (!_walkSound.isPlaying && _playerMovement.VelocityX != 0)
            {
                _walkSound.Play();
            }
        }
        else
        {
            _walkSound.Stop();
        }
    }

    private void OnStopMove()
    {
        _walkSound.Stop();
    }

    private void OnAttacked()
    {
        _attackSound.Play();
    }

    private void OnDied()
    {
        _deathSound.Play();
    }

    private void OnRaisedObject()
    {
        _coinSound.Play();
    }
}